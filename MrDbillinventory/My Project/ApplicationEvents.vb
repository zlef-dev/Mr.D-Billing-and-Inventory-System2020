Namespace My
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(ByVal eventArgs As Global.Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
            Try
                mclass.main()
            Catch ex As Exception
                Global.System.Windows.Forms.MessageBox.Show(ex.Message, "Mr. D could not start",
                    Global.System.Windows.Forms.MessageBoxButtons.OK, Global.System.Windows.Forms.MessageBoxIcon.Error)
                Return False
            End Try
            Return MyBase.OnStartup(eventArgs)
        End Function

        Protected Overrides Sub OnShutdown()
            mclass.CloseDatabase()
            MyBase.OnShutdown()
        End Sub
    End Class
End Namespace
