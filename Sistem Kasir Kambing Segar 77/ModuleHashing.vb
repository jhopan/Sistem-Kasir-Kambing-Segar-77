Imports System.Security.Cryptography
Imports System.Text

Module ModuleHashing

    ' Fungsi ini untuk mengubah password teks biasa menjadi HASH SHA256
    Public Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            ' Ubah string password menjadi array byte
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            ' Hitung hash-nya
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)

            ' Ubah array byte hasil hash menjadi string heksadesimal
            Dim builder As New StringBuilder()
            For i As Integer = 0 To hashBytes.Length - 1
                builder.Append(hashBytes(i).ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Fungsi ini untuk memverifikasi apakah password yang dimasukkan pengguna
    ' cocok dengan hash yang tersimpan di database.
    Public Function VerifyPassword(inputPassword As String, storedHash As String) As Boolean
        ' Hash password yang baru dimasukkan
        Dim hashOfInput As String = HashPassword(inputPassword)

        ' Bandingkan hash dari input dengan hash yang ada di database
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        Return comparer.Compare(hashOfInput, storedHash) = 0
    End Function

End Module