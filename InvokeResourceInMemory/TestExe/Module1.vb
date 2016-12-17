Module Module1

    Sub Main()
        Dim i As Int64 = 0
        While True
            Console.WriteLine("WriteLine {0}", i)
            Threading.Thread.Sleep(2000)
            If (i < Int64.MaxValue) Then
                i += 1
            Else
                i = 0
            End If
        End While
    End Sub

End Module
