Imports System.IO
Imports System.Reflection

Module Module1

    Sub Main()
        Dim bin As Byte() = My.Resources.TestExe
        'Dim bin As Byte() = My.Resources.TestWinFormExe
        'Dim instance As FileStream = File.Open("TestExe.exe", FileMode.Open, FileAccess.Read)
        'Dim br As New BinaryReader(instance)
        'Dim bin As Byte() = br.ReadBytes(Convert.ToInt32(instance.Length))
        'instance.Close()
        'br.Close()

        Dim a As Assembly = Assembly.Load(bin)
        Dim method As MethodInfo = a.EntryPoint
        If method IsNot Nothing Then
            'Invoke the application EntryPoint
            Try
                Dim o As Object = a.CreateInstance(method.Name)
                'Console application
                method.Invoke(o, Nothing)
            Catch ex As TargetParameterCountException
                Debug.WriteLine("Not a Console Application")
                Try
                    'Winform application
                    method.Invoke(Nothing, New Object() {New String() {"Parameter1", "Parameter2"}})
                Catch ex2 As System.Reflection.TargetParameterCountException
                    Debug.WriteLine("Also not a Windows Forms Application")
                End Try
            End Try
        Else
            Debug.WriteLine("No EntryPoint found")
        End If
        Threading.Thread.Sleep(2000)
    End Sub

End Module
