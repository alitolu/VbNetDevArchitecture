﻿Imports System.Collections.Generic
Imports TolsisWallet.Core.Entities.Concrete


Namespace Utilities.Security.Jwt
    Public Interface ITokenHelper
        Function CreateToken(ByVal user As User) As AccessToken
        'Function CreateToken(ByVal user As User, ByVal operationClaims As List(Of OperationClaim)) As AccessToken

    End Interface
End Namespace
