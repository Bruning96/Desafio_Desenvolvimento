Public Class frmDepartamentosEditar
    Private Sub frmDepartamentosEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub AbrirDepartamento(ByVal idDepartamento As Integer)

        Dim drDepartamento As DataRow = Dados.ObterDepartamento(idDepartamento)

        Me.txtID.Text = CInt(drDepartamento("ID")).ToString()
        Me.txtDescricao.Text = CStr(drDepartamento("Descricao"))


    End Sub


    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If Me.txtID.Text = "" Then
            Me.txtID.Text = "0"

        End If

        Dim ID As Integer = Integer.Parse(Me.txtID.Text)
        Dim Descricao As String = Me.txtDescricao.Text
        Dim sucesso As Boolean = Dados.GravarDepartamento(ID, Descricao)

        If Not sucesso Then

            MessageBox.Show(Me, "Falha ao gravar o departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel

        Else
            Me.DialogResult = DialogResult.OK

        End If
        Me.Close()
    End Sub

    Private Sub txtDescricao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescricao.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class