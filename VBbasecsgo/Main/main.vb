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

    Module Main

        Public csgo_proc As Process()  'csgoprocess
        Public client_dll As Integer 'handle client.dll moudle
        Public engine_dll As Integer 'handle engine.dll moudle
        'Threads
        Dim thread_aimbot As System.Threading.Thread = New System.Threading.Thread(AddressOf Aimbot.Aimbot)
        Dim thread_weapons As System.Threading.Thread = New System.Threading.Thread(AddressOf WeaponCHeck.Weapons)
        Dim thread_RCS As System.Threading.Thread = New System.Threading.Thread(AddressOf Rcs.RCS)
        Dim thread_glow As New Thread(New ThreadStart(AddressOf Glow.Glow2))
        Dim thread_bh As System.Threading.Thread = New System.Threading.Thread(AddressOf Misc.bh)
        Dim thread_noflash As System.Threading.Thread = New System.Threading.Thread(AddressOf Misc.NoFlash)
        Dim thread_ap As System.Threading.Thread = New System.Threading.Thread(AddressOf Misc.AutoPistol)

        Public Sub Main()
            csgo_proc = Process.GetProcessesByName("csgo") 'csgo process
            If csgo_proc.Length > 0 Then
                For Each [Module] As System.Diagnostics.ProcessModule In csgo_proc(0).Modules
                    If [Module].ModuleName = "client.dll" Then 'get client.dll module
                        client_dll = [Module].BaseAddress 'client.dll
                    End If
                    If [Module].ModuleName = "engine.dll" Then 'get engine.dll module
                        engine_dll = [Module].BaseAddress
                    End If
                Next
                Console.WriteLine("[>] CS:GO Found")
                Console.WriteLine("")
                thread_aimbot.Start()
                Console.WriteLine("[#] Aimbot loaded")
                Console.WriteLine("[-] FOV: " & fov)
                Console.WriteLine("[-] Smooth: " & smooth)
                Console.WriteLine("[-] Hitbox: " & hitbox)
                thread_RCS.Start()
                Console.WriteLine("[#] RCS loaded")
                thread_glow.Start()
                Console.WriteLine("[#] Glow loaded")
                Console.WriteLine("[-] Team Glow: " & glowteamenabled)
                Console.WriteLine("[-] Enemy Glow: " & glowenemyenabled)
                thread_noflash.Start()
                Console.WriteLine("[#] NoFlash loaded")
                Console.WriteLine("[-] NoFlash enabled: " & noflash_onoff)
                thread_bh.Start()
                Console.WriteLine("[#] BunnyHop loaded")
                thread_ap.Start()
                Console.WriteLine("[#] AutoPistol loaded")
                thread_weapons.Start()
                Console.WriteLine("[#] WeaponCheck loaded")
            Else
                Environment.Exit(Environment.ExitCode) 'closing cheat when the game is closed
            End If
        End Sub
    End Module
End Namespace
