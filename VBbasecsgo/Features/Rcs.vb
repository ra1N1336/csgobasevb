Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Array
Imports System.IO

' ___  _    ___ ___   __  __ ___ 
'|   \| |  | _ \ __| |  \/  | __|
'| |) | |__|  _/ _| _| |\/| | _| 
'|___/|____|_| |___(_)_|  |_|___|
'
'Author: Dlpe (DLPE.me) + unknowncheats.me members
'Funny and shitty code... Do not learn from this project
'Translated by me from C++ source
'

Namespace csgo
    Module Rcs
        Dim ViewAngle As Angle
        Dim PunchAngle As Angle
        Dim OldAngle As Angle
        Dim Angle1 As Angle

        Function GetShotsFired()
            Dim LocalBase = ReadInt(Main.client_dll + Import.LocalPlayer, 4)

            Return Convert.ToInt32(ReadInt(LocalBase + &HA2C0, 4))
        End Function

        Public Sub RCS()
            While True
                If GetAsyncKeyState(&H1) And GetShotsFired() > 1 And rcs_onoff = 1 Then
                    ViewAngle = GetAngles()
                    PunchAngle = GetPunch()

                    ViewAngle.x = ViewAngle.x + OldAngle.x
                    ViewAngle.y = ViewAngle.y + OldAngle.y

                    Angle1.x = ViewAngle.x - PunchAngle.x * 2.0F
                    Angle1.y = ViewAngle.y - PunchAngle.y * 2.0F

                    NormalizeAngle(Angle1)
                    SetAngles(Angle1)
                    GetSmooth(Angle1, OldAngle)
                    OldAngle.x = PunchAngle.x * 2.0F
                    OldAngle.y = PunchAngle.y * 2.0F

                Else
                    OldAngle.x = 0
                    OldAngle.y = 0
                End If

                Thread.Sleep(1)
            End While
        End Sub
    End Module
End Namespace

