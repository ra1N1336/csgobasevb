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
'
Namespace csgo
    Module Misc
        Public Sub NoFlash()
            While True
                Dim pLocalPlayer = ReadInt(main.client_dll + Import.LocalPlayer, 4)
                If noflash_onoff = 1 Then
                    If (ReadSingle(pLocalPlayer + Import.Flash, 4) > 0.0F) Then
                        WriteSingle(pLocalPlayer + Import.Flash, 4, 0.0F)
                    End If
                ElseIf (ReadSingle(pLocalPlayer + Import.Flash, 4) = 0.0F) Then
                    WriteSingle(pLocalPlayer + Import.Flash, 4, 255.0F)

                End If
                Threading.Thread.Sleep(100)
            End While

        End Sub

        Sub bh()
            While True
                Dim pLocalPlayer = ReadInt(main.client_dll + Import.LocalPlayer, 4)
                Dim Flags = ReadInt(pLocalPlayer + Import.Flags, 4)

                If GetAsyncKeyState(bunnyhop_key) And Flags = 257 Then
                    WriteInt(Main.client_dll + Import.Jump, 4, 5)
                    Threading.Thread.Sleep(1)
                    WriteInt(Main.client_dll + Import.Jump, 4, 4)
                Else
                    Threading.Thread.Sleep(3)
                End If
            End While
        End Sub
        Sub AutoPistol()
            If GetAsyncKeyState(autopistol_key) Then
                WriteInt(Main.client_dll + Import.Attack, 4, 1)
                Threading.Thread.Sleep(10)
                WriteInt(Main.client_dll + Import.Attack, 4, 4)

            End If

            Threading.Thread.Sleep(15)
        End Sub
    End Module
End Namespace