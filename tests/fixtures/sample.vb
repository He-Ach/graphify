Imports System
Imports System.Collections.Generic

Namespace Samples

    Public Interface IProcessor
        Function Process(ByVal data As String) As String
    End Interface

    Public Class DataProcessor
        Inherits BaseProcessor

        Private _cache As New Dictionary(Of String, String)

        Public Sub New(ByVal capacity As Integer)
            MyBase.New()
        End Sub

        Public Function Process(ByVal data As String) As String Implements IProcessor.Process
            If _cache.ContainsKey(data) Then
                Return _cache(data)
            End If
            Dim result As String = Transform(data)
            _cache(data) = result
            Return result
        End Function

        Private Function Transform(ByVal input As String) As String
            Return input.Trim().ToUpperInvariant()
        End Function

        Public Sub Reset()
            _cache.Clear()
        End Sub

    End Class

End Namespace
