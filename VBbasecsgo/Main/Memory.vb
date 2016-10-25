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
    Module Memory

        <DllImport("kernel32", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
        Public Function ReadProcessMemory(ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
        End Function

        <DllImport("kernel32", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
        Public Function WriteProcessMemory(ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
        End Function

        Public Function Read(ByVal adr As Integer, ByVal l As Integer) As Byte()
            Dim lpBuffer((l - 1)) As Byte
            Dim z2QFS9ap250JyMLqnrEfrglOsBerozhAcyOrIk2i7ax5LgJDa9597rvWK4JiECGzNWqfMSBItW As Integer = 1
            ReadProcessMemory(main.csgo_proc(0).Handle, New IntPtr(adr), lpBuffer, lpBuffer.Length, z2QFS9ap250JyMLqnrEfrglOsBerozhAcyOrIk2i7ax5LgJDa9597rvWK4JiECGzNWqfMSBItW)
            Return lpBuffer
        End Function
        Public Function ReadBool(ByVal adr As Integer, ByVal l As Integer) As Object
            Return BitConverter.ToBoolean(Read(adr, l), 0)
        End Function
        Public Function ReadInt(ByVal adr As Integer, ByVal l As Integer) As Object
            Return BitConverter.ToInt32(Read(adr, l), 0)
        End Function
        Public Function ReadLong(ByVal adr As Integer, ByVal l As Integer) As Object
            Return ToLong(Read(adr, l))
        End Function
        Public Function ReadSingle(ByVal adr As Integer, ByVal l As Integer) As Object
            Return BitConverter.ToSingle(Read(adr, l), 0)
        End Function
        Public Function ReadFloat(ByVal adr As Integer) As Single
            Return BitConverter.ToSingle(Read(adr, 4), 0)
        End Function
        Private Function ToLong(ByVal byBytes() As Byte) As Object
            Dim xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd As Long = 0
            Dim tUMbjAx5w9mt2QV8fdQ06OzqctTUKj3zhaONR8kUeKu8kdIyiT As Integer = Information.UBound(byBytes, 1) - Information.LBound(byBytes, 1)
            For i As Integer = 0 To tUMbjAx5w9mt2QV8fdQ06OzqctTUKj3zhaONR8kUeKu8kdIyiT
                If (i = 0) And ((byBytes(0) And &H80) > 0) Then
                    xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd = xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd Or CLng(Math.Round(-(byBytes(i) * Math.Pow(2.0, CDbl(8 * ((Strings.Len(xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd) - 1) - i))))))
                Else
                    xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd = xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd Or CLng(Math.Truncate(Math.Round(CDbl(byBytes(i) * Math.Pow(2.0, CDbl(8 * ((Strings.Len(xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd) - 1) - i)))))))
                End If
            Next i
            Return xw9NdKpr2d106hb8z4lr7GmRt1u24tYi4rRhzhar5q4vj47Hyl10B7bhpIA8r3pOM9FV2qwm32wKQAkr2ypIGxd
        End Function
        Public Sub Write(ByVal adr As Integer, ByVal Bytes() As Byte)
            Dim z2QFS9ap250JyMLqnrEfrglOsBerozhAcyOrIk2i7ax5LgJDa9597rvWK4JiECGzNWqfMSBItW As Integer = 1
            WriteProcessMemory(main.csgo_proc(0).Handle, New IntPtr(adr), Bytes, Bytes.Length, z2QFS9ap250JyMLqnrEfrglOsBerozhAcyOrIk2i7ax5LgJDa9597rvWK4JiECGzNWqfMSBItW)
        End Sub
        Public Sub WriteBool(ByVal adr As Integer, ByVal l As Integer, ByVal val As Boolean)
            Dim bytes((l - 1)) As Byte
            bytes = BitConverter.GetBytes(val)
            Write(adr, bytes)
        End Sub
        Public Sub WriteInt(ByVal adr As Integer, ByVal l As Integer, ByVal val As Integer)
            Dim bytes((l - 1)) As Byte
            bytes = BitConverter.GetBytes(val)
            Write(adr, bytes)
        End Sub
        Public Sub WriteSingle(ByVal adr As Integer, ByVal l As Integer, ByVal val As Single)
            Dim bytes((l - 1)) As Byte
            bytes = BitConverter.GetBytes(val)
            Write(adr, bytes)

        End Sub
    End Module
End Namespace