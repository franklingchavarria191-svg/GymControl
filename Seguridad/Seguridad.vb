Imports System.Security.Cryptography
Imports System.Text

Public Module SeguridadPassword
    Public Function CalcularHash(contrasena As String, sal As String) As String

        Dim salBytes As Byte() = Convert.FromBase64String(sal)
        Dim contrasenaBytes As Byte() = Encoding.UTF8.GetBytes(contrasena)

        Dim hash As Byte() = Rfc2898DeriveBytes.Pbkdf2(
            contrasenaBytes,
            salBytes,
            100000,
            HashAlgorithmName.SHA256,
            32
        )
        Return Convert.ToBase64String(hash)
    End Function

    Public Function Verificar(
        contrasena As String,
        sal As String,
        hashGuardado As String
    ) As Boolean

        Dim calculado As Byte() =
            Convert.FromBase64String(
                CalcularHash(contrasena, sal)
            )

        Dim guardado As Byte() =
            Convert.FromBase64String(hashGuardado)

        Return CryptographicOperations.FixedTimeEquals(
            calculado,
            guardado
        )

    End Function
End Module