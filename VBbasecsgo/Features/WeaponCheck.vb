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
    Module WeaponCHeck
        Public Function GetLocalBase()
            Return ReadInt(Main.client_dll + Import.LocalPlayer, 4)
        End Function

        Public Sub Weapons()
            While True
                Dim hActiveWeapon = ReadInt(GetLocalBase() + &H2EE8, 4)
                Dim wepEntity = ReadInt(Main.client_dll + Import.EntityList + ((hActiveWeapon And &HFFF) - 1) * &H10, 4)
                Dim wepIndex = ReadInt(wepEntity + Import.iItemDefinitionIndex, 4)
            End While
        End Sub

#Region "Weapon ID"
        Public Class WeaponID
            'Pistols
            Public Const Glock As Integer = 4
            Public Const USP As Integer = 61
            Public Const P2000 As Integer = 32
            Public Const P250 As Integer = 36
            Public Const FiveSeven As Integer = 3
            Public Const Tec9 As Integer = 30
            Public Const CZ75 As Integer = 63
            Public Const Deagle As Integer = 1
            Public Const Duals As Integer = 2

            'Heavy
            Public Const Nova As Integer = 35
            Public Const SawedOff As Integer = 29
            Public Const Mag7 As Integer = 27
            Public Const XM1014 As Integer = 25
            Public Const M249 As Integer = 14
            Public Const Negev As Integer = 28


            'SMG's
            Public Const MP9 As Integer = 34
            Public Const MAC10 As Integer = 17
            Public Const MP7 As Integer = 33
            Public Const Bizon As Integer = 26
            Public Const UMP45 As Integer = 24
            Public Const P90 As Integer = 19

            'Rifles
            Public Const Famas As Integer = 10
            Public Const Galil As Integer = 13
            Public Const AK47 As Integer = 7
            Public Const M4A4 As Integer = 16
            Public Const M4A1S As Integer = 60
            Public Const Krieg As Integer = 39
            Public Const Bullpup As Integer = 8

            'Snipers
            Public Const Scout As Integer = 40
            Public Const AWP As Integer = 9
            Public Const SCAR20 As Integer = 38
            Public Const G3SG1 As Integer = 11

            Public Structure Knifes
                Const Karambit As Integer = 507
                Const Knife As Integer = 59
                Const KnifeCT As Integer = 42
                Const Zeus As Integer = 31
                Const Butterfly As Integer = 515
                Const ShadowDaggers As Integer = 516
                Const Huntsman As Integer = 509
                Const FlipKnife As Integer = 505
                Const Bayonet As Integer = 500
                Const M9Knife As Integer = 508
                Const Falchion As Integer = 512
                Const GutKnife As Integer = 506
            End Structure

            Public Structure Nades
                Const Grenade As Integer = 44
                Const SmokeNade As Integer = 45
                Const Flash As Integer = 43
                Const Decoy As Integer = 47
                Const Molotov As Integer = 46
                Const Incendiary As Integer = 48
                Const C4 As Integer = 49
            End Structure

        End Class
#End Region

    End Module
End Namespace