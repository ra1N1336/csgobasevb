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
'Credits for aimbot code going to m3mer source
'

Namespace csgo
    Module Aimbot
        Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
        Public bAimbotting As Boolean = False

        Public Structure Angle
            Public x As Single
            Public y As Single
            Public z As Single
            Private _p1 As Single
            Private _p2 As Single
            Private _p3 As Single

            Sub New(p1 As Single, p2 As Single, p3 As Single)
                ' TODO: Complete member initialization 
                _p1 = p1
                _p2 = p2
                _p3 = p3
            End Sub

        End Structure

        Public Structure Trace
            Public allsolid As Boolean
            Public startsolid As Boolean
            Public Fraction As Single
            Public endpos As Angle
            Public SurfaceFlags As Integer
            Public Contents As Integer
            Public EntityNum As Integer
        End Structure

        Public Function GetBonePosition(ByVal pTargetPlayer As Integer, ByVal pBoneID As Integer)
            Dim pAngle As Angle = New Angle
            Dim BoneMatrix = ReadInt(pTargetPlayer + Import.BoneMatrix, 4)
            pAngle.x = ReadSingle(BoneMatrix + &H30 * pBoneID + &HC, 4)
            pAngle.y = ReadSingle(BoneMatrix + &H30 * pBoneID + &H1C, 4)
            pAngle.z = ReadSingle(BoneMatrix + &H30 * pBoneID + &H2C, 4)

            Return pAngle
        End Function

        Public Function _NormalizeAngle(ByVal pAngle As Single)
            Return ((pAngle + 180) Mod 360) - 180
        End Function

        Public Function AngleDifference(ByVal pAngleA As Angle, ByVal pAngleB As Angle)
            Dim bX180 As Boolean = False
            Dim bY180 As Boolean = False
            Dim XDiff As Single = _NormalizeAngle(pAngleA.x - pAngleB.x)
            Dim YDiff As Single = _NormalizeAngle(pAngleA.y - pAngleB.y)

            bX180 = 180 > XDiff
            bY180 = 180 > YDiff

            If Not bX180 Then
                XDiff = XDiff - 360
            End If

            If Not bY180 Then
                YDiff = YDiff - 360
            End If

            If 0 > XDiff Then
                XDiff = (XDiff - XDiff) - XDiff
            End If

            If 0 > YDiff Then
                YDiff = (YDiff - YDiff) - YDiff
            End If

            Return XDiff + YDiff
        End Function


        Public Function NormalizeAngle(ByVal pAngle As Angle)
            If pAngle.x > 89 Then
                pAngle.x = 89
            ElseIf -89 > pAngle.x Then
                pAngle.x = -89
            End If

            If pAngle.y > 180 Then
                pAngle.y = pAngle.y - 360
            ElseIf -180 > pAngle.y Then
                pAngle.y = pAngle.y + 360
            End If

            pAngle.z = 0
            Return pAngle
        End Function

        Public Function GetOrigin()
            Dim pLocalPlayer = ReadInt(Main.client_dll + Import.LocalPlayer, 4)
            Dim pOrigin As Angle = New Angle
            pOrigin.x = ReadSingle(pLocalPlayer + Import.VecOrigin, 4)
            pOrigin.y = ReadSingle(pLocalPlayer + Import.VecOrigin + &H4, 4)
            pOrigin.z = ReadSingle(pLocalPlayer + Import.VecOrigin + &H4 + &H4, 4)

            Return pOrigin
        End Function

        Public Function GetPunch()
            Dim pLocalPlayer = ReadInt(Main.client_dll + Import.LocalPlayer, 4)
            Dim pAngle As Angle = New Angle
            pAngle.x = ReadSingle(pLocalPlayer + Import.VecPunch, 4)
            pAngle.y = ReadSingle(pLocalPlayer + Import.VecPunch + &H4, 4)
            pAngle.z = 0

            Return pAngle
        End Function

        Public Function GetAngles()
            Dim pAnglePointer As Integer = ReadInt(Main.engine_dll + Import.Engine, 4)
            Dim pAngle As Angle = New Angle
            pAngle.x = ReadSingle(pAnglePointer + Import.ViewAngles, 4)
            pAngle.y = ReadSingle(pAnglePointer + Import.ViewAngles + &H4, 4)
            pAngle.z = 0

            Return pAngle
        End Function


        Public Sub SetAngles(ByVal pAngle As Angle)
            Dim pAnglePointer As Integer = ReadInt(Main.engine_dll + Import.Engine, 4)
            WriteSingle(pAnglePointer + Import.ViewAngles, 4, pAngle.x)
            WriteSingle(pAnglePointer + Import.ViewAngles + &H4, 4, pAngle.y)
        End Sub

        Public Function mAngle(ByVal x As Single, ByVal y As Single, ByVal z As Single)
            Dim pAngle As Angle = New Angle
            pAngle.x = x
            pAngle.y = y
            pAngle.z = z

            Return pAngle
        End Function




        Public Function GetSmooth(ByVal pOriginal As Angle, ByVal pDest As Angle) As Object

            Dim pAngle As Angle = New Angle
            pAngle.x = pDest.x - pOriginal.x
            pAngle.y = pDest.y - pOriginal.y
            pAngle = NormalizeAngle(pAngle)

            pAngle.x = pOriginal.x + pAngle.x / 100 * smooth
            pAngle.y = pOriginal.y + pAngle.y / 100 * smooth
            pAngle = NormalizeAngle(pAngle)

            Return NormalizeAngle(pAngle)
        End Function


        Dim smooth As Integer
        Dim smoothedangle As Angle
        Dim sourceangle As Angle



        Public Function CalcAngle(PlayerPosition As Angle, EnemyPosition As Angle, PunchAngle As Angle, ViewOffset As Angle) As Angle
            Dim AimAngle As New Angle

            Dim Delta As New Angle((PlayerPosition.x - EnemyPosition.x), (PlayerPosition.y - EnemyPosition.y), ((PlayerPosition.z + ViewOffset.z) - EnemyPosition.z))
            Dim hyp As Single = Math.Sqrt(Delta.x * Delta.x + Delta.y * Delta.y)
            AimAngle.x = Math.Atan(Delta.z / hyp) * 57.29578F - PunchAngle.x * 1
            AimAngle.y = Math.Atan(Delta.y / Delta.x) * 57.29578F - PunchAngle.y * 1
            AimAngle.z = 0.0F
            If Delta.x >= 0.0 Then
                AimAngle.y += 180.0F
            End If
            Return NormalizeAngle(AimAngle)
        End Function


        Public Function CalcAngle(ByVal pSource As Angle, ByVal pDestination As Angle)
            Dim pLocalPlayer = ReadInt(Main.client_dll + Import.LocalPlayer, 4)
            Dim pDelta As Angle = New Angle
            pDelta.x = pSource.x - pDestination.x
            pDelta.y = pSource.y - pDestination.y
            Dim pViewOrigin = ReadSingle(pLocalPlayer + Import.ViewOffset + &H4 + &H4, 4)
            pDelta.z = pSource.z + pViewOrigin - pDestination.z

            Dim siHyp As Single = Math.Sqrt(pDelta.x * pDelta.x + pDelta.y * pDelta.y)

            Dim pPunch As Angle = New Angle
            pPunch = GetPunch()

            Dim pAngle As Angle = New Angle
            pAngle.x = Math.Atan(pDelta.z / siHyp) * 57.295779513082 - pPunch.x * 1
            pAngle.y = Math.Atan(pDelta.y / pDelta.x) * 57.295779513082 - pPunch.y * 1
            pAngle.z = 0

            If pDelta.x >= 0.0 Then
                pAngle.y = pAngle.y + 180
            End If

            Return pAngle
        End Function

        Public Sub Aimbot()
            While True
                If GetAsyncKeyState(&H1) And aim_onoff = 1 Then
                    Dim pLocalPlayer = ReadInt(Main.client_dll + Import.LocalPlayer, 4)
                    Dim pLocalTeam = ReadInt(pLocalPlayer + Import.Team, 4)
                    Dim pAngles = GetAngles()
                    Dim pOrigin = GetOrigin()

                    Dim pBone As Integer = 6

                    If Not hitbox = "" And Not hitbox = " " And Not Convert.ToInt32(hitbox) = 0 Then
                        pBone = Convert.ToInt32(hitbox)
                    End If

                    For i As Integer = 1 To 64
                        Dim pCurPlayer = ReadInt(Main.client_dll + Import.EntityList + ((i - 1) * 16), 4)

                        If pCurPlayer = 0 Then
                            Continue For
                        End If

                        Dim pCurPlayerTeam = ReadInt(pCurPlayer + Import.Team, 4)
                        Dim pCurPlayerDormant = ReadBool(pCurPlayer + Import.Dormant, 4)
                        Dim pCurPlayerHealth = ReadInt(pCurPlayer + Import.Health, 4)

                        If Not pLocalTeam = pCurPlayerTeam And Not pCurPlayerDormant And Not 0 >= pCurPlayerHealth Then
                            Dim pAngle = GetBonePosition(pCurPlayer, pBone)
                            pAngle = CalcAngle(pOrigin, pAngle)
                            pAngle = NormalizeAngle(pAngle)

                            If AngleDifference(pAngles, pAngle) > Convert.ToSingle(fov) Or Not SpottedByMask(pCurPlayer) Then
                                Continue For
                            End If

                            bAimbotting = True
                            pAngle.x = pAngle.x - GetPunch().x * 2
                            pAngle.y = pAngle.y - GetPunch().y * 2
                            SetAngles(GetSmooth(pAngles, pAngle))

                            Exit For
                        End If


                    Next

                    bAimbotting = False

                    Threading.Thread.Sleep(1)

                End If

            End While

        End Sub

        Public Function SpottedByMask(ByVal pPlayer As Integer)
            Dim pMask As Long = ReadInt(pPlayer + Import.Spotted, 4)
            Dim pLocalIndex As Integer = ReadInt(Main.client_dll + Import.EntityList, 4)
            Return CBool(pMask And (1 << (pLocalIndex)) > 0)
        End Function

    End Module
End Namespace