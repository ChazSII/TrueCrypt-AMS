Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Principal
Imports System.Reflection

NotInheritable Class Program

    Private Sub New()
    End Sub

    Private Shared Function IsRunAsAdministrator() As Boolean
        Dim wi = WindowsIdentity.GetCurrent()
        Dim wp = New WindowsPrincipal(wi)

        Return wp.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread> _
    Public Shared Sub Main()
        '*************************** Unhandeld exception catch ******************************************************
        '* Create an handler that will be called by the framework when a unhandeld exception is detected
        '************************************************************************************************************

        Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler myCurrentDomain.UnhandledException, New UnhandledExceptionEventHandler(AddressOf myCurrentDomain_UnhandledException)

        '******************* NO Form ********************************************************
        '* Here you create the class that will serve as the main
        '* instead of loading the form and then hiding it. 
        '* The class should call Application.Exit() when exit time comes.
        '* The form will only be created and kept in memory when its actually used.
        '* Note that Application.Run does not start any form
        '* Application.SetCompatibleTextRenderingDefault() should not be called when there is no form
        '* Checker is a Singleton
        '************************************************************************************

        If Not IsRunAsAdministrator() Then
            ' It is not possible to launch a ClickOnce app as administrator directly, so instead we launch the
            ' app as administrator in a new process.
            Dim processInfo = New ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)

            ' The following properties run the new process as administrator
            processInfo.UseShellExecute = True
            processInfo.Verb = "runas"

            ' Start the new process
            Try
                Process.Start(processInfo)
            Catch ex As Exception
                ' The user did not allow the application to run as administrator
                MessageBox.Show("Sorry, this application must be run as Administrator.")
            End Try

            ' Shut down the current process
            Application.Exit()
        Else
            ' We are running as administrator

            Try
                Using TrayApp_1 As New TrayApp
                    Application.EnableVisualStyles()
                    Application.Run()
                End Using
            Catch ex As Exception
                myCurrentDomain_UnhandledException(Nothing, New UnhandledExceptionEventArgs(ex, True))
            End Try
        End If
    End Sub

    Private Shared Sub myCurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim [error] As String = ""

        Try
            Dim unhandeld As Exception = DirectCast(e.ExceptionObject, Exception)
            [error] = "++++++++++++++++++++++++++++UNHANDELD EXCEPTION++++++++++++++++++++++++++++++++++++++++++++" & vbCr & vbLf
            [error] += DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:fff") + vbCr & vbLf
            [error] += "CLS Terminating = " + e.IsTerminating.ToString() + vbCr & vbLf
            [error] += "------------------------------------------------------------------------------------------" & vbCr & vbLf
            [error] += "Exception:" & vbCr & vbLf
            [error] += "Message: " + unhandeld.Message + vbCr & vbLf
            [error] += "Source:  " + unhandeld.Source + vbCr & vbLf
            [error] += "StackTrace:  " + unhandeld.StackTrace + vbCr & vbLf
            [error] += "==========================================================================================" & vbCr & vbLf
            [error] += "Innerexception Message: " & vbCr & vbLf
            If unhandeld.InnerException IsNot Nothing Then
                [error] += unhandeld.InnerException.Message + vbCr & vbLf
                [error] += "Source:  " + unhandeld.InnerException.Source + vbCr & vbLf
                [error] += "StackTrace:  " + unhandeld.InnerException.StackTrace + vbCr & vbLf
            End If
            [error] += "==========================================================================================" & vbCr & vbLf
            Using writer As New StreamWriter("unhandled.txt", True)
                writer.WriteLine([error])
                writer.Flush()
            End Using
        Catch more As Exception
            ''even more misery
            'Using ErrMsg As New ErrorDisplay
            '    ErrMsg.txtError.Text = ([error] & Convert.ToString(" additional problem: ")) + more.Message
            '    ErrMsg.ShowDialog()
            'End Using
        Finally
            'cleanup 
            If e.IsTerminating Then
                'Using ErrMsg As New ErrorDisplay
                '    ErrMsg.txtError.Text = [error]
                '    ErrMsg.ShowDialog()
                'End Using
            End If
        End Try

    End Sub

End Class