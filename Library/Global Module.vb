Imports MySql.Data.MySqlClient
Module Global_Module
    Public myFont As New Font("Inter", 28, FontStyle.Regular)
    Property conn As New MySqlConnection("Server=127.0.0.1;Port=3307;Database=library_management;User ID=root;Password=;")

    Property reader As MySqlDataReader
    Public Sub dbConn()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub dbDisconn()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

End Module
