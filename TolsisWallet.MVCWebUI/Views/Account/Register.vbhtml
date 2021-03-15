@Code
    ViewData("Title") = "Register"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Üye Ol</h2>

<hr />
<script type="text/javascript">
    $(document).ready(function () {

        $("#Register").click(function () {

            var email = $("#email").val();
            var password = $("#password").val();
            var repassword = $("#repassword").val();
            var firstname = $("#firstname").val();
            var lastname = $("#lastname").val();
            var phone = $("#phone").val();
           
            var user = {
                Email: email,
                PasswordSalt: password,
                PasswordVerify: repassword,
                FirstName: firstname,
                LastName: lastname,
                MobilePhone: phone
            }

            $.ajax({
                type: "POST",
                url: '/Account/Register',
                data: JSON.stringify(user),
                contentType: 'application/json; charset=utf-8',
                beforeSend: function () {
                    $("#Register").prop("disabled", true);
                    $("#Register").html('Bekleyiniz...');
                },
                success: function (data) {
                    alert(data.msg);
                },
                complete: function () {
                    $("#Register").prop("disabled", false);
                    $("#Register").html('Üye Ol');
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        });
    });
</script>
<div class="row">
    <aside class="col-sm-4"></aside>
    <aside class="col-sm-4">
        <div class="card">
            <article class="card-body">
                <div class="form-group">
                    <label>E-Mail</label>
                    <input name="email" id="email" class="form-control" placeholder="Email" type="email">
                </div>
                <div class="form-group">
                    <label>Adı</label>
                    <input name="firstname" id="firstname" class="form-control" placeholder="Adınız" type="text">
                </div>
                <div class="form-group">
                    <label>Soy Adı</label>
                    <input name="lastname" id="lastname" class="form-control" placeholder="Soy isminiz" type="text">
                </div>
                <div class="form-group">
                    <label>Cep Telefonu</label>
                    <input name="phone" id="phone" class="form-control" placeholder="cep telefonu" type="text">
                </div>
                <div class="form-group">
                    <label>Şifre</label>
                    <input name="password" id="password" class="form-control" placeholder="******" type="password">
                </div>
                <div class="form-group">
                    <label>Şifre Doğrula</label>
                    <input name="repassword" id="repassword" class="form-control" placeholder="******" type="password">
                </div>
                <div class="form-group">
                    <div class="checkbox">
                        <label> <input type="checkbox"> Kullanım şartlarını okudum ve anladım !</label>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary" id="Register">Üye Ol</button>
            </article>
            <hr />
        </div>
    </aside>
    <aside class="col-sm-4"></aside>
</div>