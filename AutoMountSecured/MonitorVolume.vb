Imports System.IO
Imports DeviceMonitor

Public Class MonitorVolume
    Implements IDisposable

    Private _Target_Drive_Letter As String = ""
    Private _Secured_Drive_Letter As String = ""
    Private _Target_Volume_Name As String = ""

    Private WithEvents DeviceMonitor As New DriveDetector()

    Public Event DriveChange(sender As Object, e As StatusChangeEventArgs)

    'Public ReadOnly Property IsSecuredDriveMounted As Boolean
    '    Get
    '        If _Secured_Drive_Letter = "" Then
    '            Return False
    '        Else
    '            Return (New IO.DriveInfo(_Secured_Drive_Letter)).IsReady
    '        End If
    '    End Get
    'End Property
    'Public ReadOnly Property IsTargetDriveMounted As Boolean
    '    Get
    '        If TargetDriveLetter = "" Then
    '            Return False
    '        Else
    '            Return (New IO.DriveInfo(TargetDriveLetter)).IsReady
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property TargetDriveLetter As String
        Get
            Return _Target_Drive_Letter
        End Get
    End Property

    ''' <summary>
    ''' Detects insertion or removal of a specific removable named voloume .
    ''' </summary>
    ''' <param name="TargetVolumeName">The name of the volume to monitor for.</param>
    ''' <param name="SecuredDriveLetter">The drive letter that will be mounted.</param>
    ''' <remarks></remarks>
    Public Sub StartMonitor(ByVal TargetVolumeName As String, ByVal SecuredDriveLetter As String)
        _Target_Volume_Name = TargetVolumeName
        _Secured_Drive_Letter = SecuredDriveLetter

        For Each Drive As DriveInfo In DriveInfo.GetDrives
            If Not Drive.IsReady Then Continue For

            If Drive.VolumeLabel = TargetVolumeName Then
                _Target_Drive_Letter = Drive.Name
                If Not DeviceMonitor.IsQueryHooked Then DeviceMonitor.EnableQueryRemove(_Target_Drive_Letter)

                RaiseEvent DriveChange(Me, New StatusChangeEventArgs(Drive.Name(0),
                                                                     StatusChange.Insert,
                                                                     VolumeType.Target))
            ElseIf Drive.Name(0) = SecuredDriveLetter Then
                RaiseEvent DriveChange(Me, New StatusChangeEventArgs(Drive.Name(0),
                                                                     StatusChange.Insert,
                                                                     VolumeType.Secured))
            End If
        Next
    End Sub

    Private Sub VolumeInserted(sender As Object, e As DriveDetectorEventArgs) Handles DeviceMonitor.DeviceArrived
        '// -------------------------
        '// A volume was inserted
        '// -------------------------
        Dim Volume As New System.IO.DriveInfo(e.Drive)

        If Volume.IsReady AndAlso Volume.VolumeLabel = _Target_Volume_Name Then
            _Target_Drive_Letter = Volume.Name

            If Not DeviceMonitor.IsQueryHooked Then DeviceMonitor.EnableQueryRemove(e.Drive)

            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Insert,
                                                                 VolumeType.Target))
        ElseIf Volume.IsReady AndAlso e.Drive(0) = _Secured_Drive_Letter Then

            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Insert,
                                                                 VolumeType.Secured))
        End If

    End Sub

    Private Sub Volume_Removing(sender As Object, e As DriveDetectorEventArgs) Handles DeviceMonitor.QueryRemove
        '// -------------------------
        '// A volume is removing
        '// -------------------------

        If _Target_Drive_Letter = e.Drive Then
            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Removing,
                                                                 VolumeType.Target))
        ElseIf _Secured_Drive_Letter = e.Drive(0) Then
            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Removing,
                                                                 VolumeType.Secured))
        End If
    End Sub

    Private Sub VolumeRemoved(sender As Object, e As DriveDetectorEventArgs) Handles DeviceMonitor.DeviceRemoved
        '// --------------------
        '// A volume was removed
        '// --------------------

        If _Secured_Drive_Letter = e.Drive(0) Then
            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Removed,
                                                                 VolumeType.Secured))
        ElseIf _Target_Drive_Letter = e.Drive Then
            _Target_Drive_Letter = ""

            RaiseEvent DriveChange(Me, New StatusChangeEventArgs(e.Drive(0),
                                                                 StatusChange.Removed,
                                                                 VolumeType.Target))
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                DeviceMonitor.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class



Public Class StatusChangeEventArgs
    Inherits EventArgs

    Private Property _Drive As Char
    Public ReadOnly Property DriveLetter As Char
        Get
            Return _Drive
        End Get
    End Property

    Private Property _Event As StatusChange
    Public ReadOnly Property [Event] As StatusChange
        Get
            Return _Event
        End Get
    End Property

    Private Property _Volume As VolumeType
    Public ReadOnly Property Volume As VolumeType
        Get
            Return _Volume
        End Get
    End Property

    Public Sub New(ByVal DriveLetter As Char, ByVal EventType As StatusChange, ByVal VolumeType As VolumeType)
        _Event = EventType
        _Drive = DriveLetter
        _Volume = VolumeType
    End Sub

End Class

Public Enum StatusChange
    Insert = 0
    Removing = 1
    Removed = 2
End Enum

Public Enum VolumeType
    Target = 0
    Secured = 1
End Enum