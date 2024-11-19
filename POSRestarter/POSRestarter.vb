Imports System
Imports System.Diagnostics
Imports System.Threading

Module POSRestarter
    Sub Main()
        Try
            Dim posProcessId As Integer = Process.GetCurrentProcess().Id

            Try
                Dim posProcess As Process = Process.GetProcessById(posProcessId)
                posProcess.WaitForExit(10000)
            Catch ex As Exception
            End Try

            Thread.Sleep(2000)

            For Each proc As Process In Process.GetProcessesByName("POSMAIN")
                Try
                    proc.Kill()
                    proc.WaitForExit(5000)
                Catch ex As Exception
                End Try
            Next
            Thread.Sleep(2000)
            Process.Start("POSMAIN.EXE")

        Catch ex As Exception
            Environment.Exit(1)
        End Try
    End Sub
End Module