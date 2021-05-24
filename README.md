# JuntoSeguros

Teste prático

Para controller de Login receber o bearer na url do swagger; Usuário do Seed;
User:admin_Usuario
Pwd: AdminUsuario01!

Favor usar uma senha forte como AdminUsuario01!, o usuario é do Identity e exige essa configuração de segurança.

Caso o swagger não entenda a policy Bearer, favor comentar o [Authorize("Bearer")] na controller UsuarioController, linha 12.

Deste modo é possível testar os endpoints via UI.
http://localhost:55491/swagger/index.html
