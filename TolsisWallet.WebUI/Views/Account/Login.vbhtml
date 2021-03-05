@Code
    ViewData("Title") = "Tolsis Üye Girişi"
End Code
<h2>Üye Girişi</h2>
<hr />

<script type="text/javascript">
    $(document).ready(function () {

        $("#Giris").click(function () {

            $("#alert").hide();

            var txtEmail = $("#email").val();
            var txtPass = $("#password").val();
            var user = {
                email: txtEmail,
                password: txtPass
            }

            $.ajax({
                type: "POST",
                url: '/Account/Login',
                data: JSON.stringify(user),
                contentType: 'application/json; charset=utf-8',
                beforeSend: function () {
                    $("#Giris").prop("disabled", true);
                    $("#Giris").html('Bekleyiniz...');
                },
                success: function (data) {
                    if (data.msg == "ok") {
                        alert(data.msg);
                        $("#alert").hide();
                    } else {
                        alert(data.msg);
                        $("#alert").show();
                    }
                },
                complete: function () {
                    $("#Giris").prop("disabled", false);
                    $("#Giris").html('Giriş');
                },
                error: function () {
                    alert("Error occured!!")
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
                    <label>Şifre</label>
                    <input name="password" id="password" class="form-control" placeholder="******" type="password">
                </div>
                <div class="form-group">
                    <div class="checkbox">
                        <label> <input type="checkbox"> Beni hatırla !</label>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary" id="Giris"> Giriş </button>
            </article>
            <hr />
            <div class="alert alert-danger" role="alert" id="alert" style="display:none">
                Kullanıcı veya şifre hatalı
            </div>
        </div>
    </aside>
    <aside class="col-sm-4"></aside>
</div>
