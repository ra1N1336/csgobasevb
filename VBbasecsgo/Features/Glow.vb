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
'Translated by me from C++ source
'

Namespace csgo
    Module Glow
        Public Structure GlowStruct
            Public r As Single
            Public g As Single
            Public b As Single
            Public a As Single
            Public rwo As Boolean
            Public rwuo As Boolean
        End Structure

        Private Sub DrawGlow(ByVal pGlowIn As Integer, ByVal GlowS As GlowStruct)
            Dim GlowO As Object = RuntimeHelpers.GetObjectValue(ReadInt(main.client_dll + Import.GlowObject, 4))
            WriteSingle(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + 4)), 4, GlowS.r)
            WriteSingle(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + 8)), 4, GlowS.g)
            WriteSingle(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + 12)), 4, GlowS.b)
            WriteSingle(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + &H10)), 4, GlowS.a)
            WriteBool(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + &H24)), 1, GlowS.rwo)
            WriteBool(Conversions.ToInteger(Operators.AddObject(GlowO, (pGlowIn * &H38) + &H25)), 1, GlowS.rwuo)
        End Sub

        Public Sub Glow2()
            Do

                Dim NH74C9QB6pmK4b6cmlwbcf3tXXybpuwBYjGpM3B2vZ1ZWG0Ch66r5Cyv5 As GlowStruct = New GlowStruct With {
                    .r = CSng((CDbl(glow_enemy_r)) / 255.0),
                    .g = CSng((CDbl(glow_enemy_g)) / 255.0),
                    .b = CSng((CDbl(glow_enemy_b)) / 255.0),
                    .a = CSng((CDbl(glow_alpha)) / 255.0),
                    .rwo = True,
                    .rwuo = False
                }
                Dim pSMuzsWARsA3qkXxMogW2PAmF21cDncM0T241HHOzztikLT3gphegfQC6fAWE92JlfeLJhW5E9MRs9061e87d As GlowStruct = New GlowStruct With {
                    .r = CSng((CDbl(glow_team_r)) / 255.0),
                    .g = CSng((CDbl(glow_team_g)) / 255.0),
                    .b = CSng((CDbl(glow_team_b)) / 255.0),
                    .a = CSng((CDbl(glow_alpha)) / 255.0),
                    .rwo = True,
                    .rwuo = False
                }
                If glowenemyenabled = 1 Or glowteamenabled = 1 Then

                    Dim vQVQGwk2XxL2zhaXRmQ2CI74RR5IqlLLCalj3bw1JM24b5 As Integer
                    Dim xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd As Integer = 1
                    Do
                        Dim n3xsZL0O80kA30ghm16ezU86h3xqtn3u3MORrhynIgprwobqd28arjIL3nBn9i5ayePgw As Object = RuntimeHelpers.GetObjectValue(ReadInt(Main.client_dll + Import.LocalPlayer, 4))
                        Dim rOnSZwb9Y2Ug3YX17fz4T6gOW4bjxM59zjOf4LgqPIw3ePFyHgsrygCOi3S1wvm52mPhCXX45beGd8nM70ou4AaPX As Object = RuntimeHelpers.GetObjectValue(ReadInt((Main.client_dll + Import.EntityList) + ((xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd - 1) * &H10), 4))
                        If Conversions.ToBoolean(Operators.NotObject(RuntimeHelpers.GetObjectValue(ReadBool(Conversions.ToInteger(Operators.AddObject(rOnSZwb9Y2Ug3YX17fz4T6gOW4bjxM59zjOf4LgqPIw3ePFyHgsrygCOi3S1wvm52mPhCXX45beGd8nM70ou4AaPX, Import.Dormant)), 4)))) Then
                            Dim jNKFVt9H4ZIAlyI67i05wobD9bx76wb As Object = RuntimeHelpers.GetObjectValue(ReadInt(Conversions.ToInteger(Operators.AddObject(rOnSZwb9Y2Ug3YX17fz4T6gOW4bjxM59zjOf4LgqPIw3ePFyHgsrygCOi3S1wvm52mPhCXX45beGd8nM70ou4AaPX, Import.GlowIndex)), 4))
                            Dim lcItS8PET6B6C4Y6wobYE6c2527bx416X5Y8g8Lvw358UDn9jmKTdo50z0j5 As Object = RuntimeHelpers.GetObjectValue(ReadInt(Conversions.ToInteger(Operators.AddObject(rOnSZwb9Y2Ug3YX17fz4T6gOW4bjxM59zjOf4LgqPIw3ePFyHgsrygCOi3S1wvm52mPhCXX45beGd8nM70ou4AaPX, Import.Team)), 4))
                            Dim KsEM82QFaApdx3mR9QjM2HuaKK97K88g5tJFgutveys3K38OV79bxUq4QOZ07d2EL2 As Object = RuntimeHelpers.GetObjectValue(ReadInt(Conversions.ToInteger(Operators.AddObject(n3xsZL0O80kA30ghm16ezU86h3xqtn3u3MORrhynIgprwobqd28arjIL3nBn9i5ayePgw, Import.Team)), 4))
                            If Operators.ConditionalCompareObjectEqual(lcItS8PET6B6C4Y6wobYE6c2527bx416X5Y8g8Lvw358UDn9jmKTdo50z0j5, KsEM82QFaApdx3mR9QjM2HuaKK97K88g5tJFgutveys3K38OV79bxUq4QOZ07d2EL2, False) Then
                                If glowteamenabled = "1" Then

                                    DrawGlow(Conversions.ToInteger(jNKFVt9H4ZIAlyI67i05wobD9bx76wb), pSMuzsWARsA3qkXxMogW2PAmF21cDncM0T241HHOzztikLT3gphegfQC6fAWE92JlfeLJhW5E9MRs9061e87d)
                                End If
                            Else
                                If glowenemyenabled = "1" Then

                                    DrawGlow(Conversions.ToInteger(jNKFVt9H4ZIAlyI67i05wobD9bx76wb), NH74C9QB6pmK4b6cmlwbcf3tXXybpuwBYjGpM3B2vZ1ZWG0Ch66r5Cyv5)
                                End If
                            End If
                        End If

                        xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd += 1
                        vQVQGwk2XxL2zhaXRmQ2CI74RR5IqlLLCalj3bw1JM24b5 = &H40
                    Loop While xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd <= vQVQGwk2XxL2zhaXRmQ2CI74RR5IqlLLCalj3bw1JM24b5
                End If
                Thread.Sleep(&H11)
            Loop
        End Sub
    End Module
End Namespace
