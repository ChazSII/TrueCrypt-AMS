﻿Imports TrueCryptDriver.Security

Namespace Common
    Namespace Structures
        Public Structure MOUNT_OPTIONS
            Dim [ReadOnly] As Boolean
            Dim Removable As Boolean
            Dim ProtectHiddenVolume As Boolean
            Dim PreserveTimestamp As Boolean
            Dim PartitionInInactiveSysEncScope As Boolean
            Dim ProtectedHidVolPassword As Password
            Dim UseBackupHeader As Boolean
            Dim RecoveryMode As Boolean
        End Structure
    End Namespace
End Namespace