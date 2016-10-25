Imports System.Text.RegularExpressions
Imports System.Net.Mime.MediaTypeNames
Imports System.Management
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
'Simple InCross trigger, angle trigger comming soon (idk when)
'Its C+P fro m3mer source
'
Namespace csgo
    Module Trigger
        Public Sub Trigger()
            While True
                If GetAsyncKeyState(trigger_key) And trigger_onoff = 1 Then
                    Dim pLocalPlayer = ReadInt(Main.client_dll + Import.LocalPlayer, 4)
                    Dim pInCross = ReadInt(pLocalPlayer + Import.CrossHair, 4)

                    If pInCross > 0 And pInCross < 65 Then
                        Dim Team = ReadInt(pLocalPlayer + Import.Team, 4)
                        Dim pInCrossPlayer = ReadInt(Main.client_dll + Import.EntityList + ((pInCross - 1) * &H10), 4)
                        Dim InCrossTeam = ReadInt(pInCrossPlayer + Import.Team, 4)

                        If Not Team = InCrossTeam Then
                            Threading.Thread.Sleep(trigger_delay)
                            WriteInt(Main.client_dll + Import.Attack, 4, 1)
                            Threading.Thread.Sleep(10)
                            WriteInt(Main.client_dll + Import.Attack, 4, 4)
                        End If
                    End If
                End If

                Threading.Thread.Sleep(1)
            End While
        End Sub
    End Module
End Namespace
