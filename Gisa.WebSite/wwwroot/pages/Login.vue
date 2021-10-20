<template>
    <main class="d-flex align-items-center min-vh-100 py-3 py-md-0" style="background-color: #d0d0ce">
        <div class="container">
            <div class="card login-card">
                <div class="row no-gutters">
                    <div class="col-md-6">
                        <img src="images/login.jpg" alt="login" class="login-card-img">
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div class="brand-wrapper">
                                <img src="images/logo1.png" alt="logo" class="logo">
                            </div>
                            <p class="login-card-description">Informe seus dados</p>
                            <form method="POST" accept-charset="UTF-8" class="m-0" @submit.prevent="login()">
                                <div class="form-group">
                                    <label for="email" class="sr-only">Usuário</label>
                                    <input type="text" name="email" id="email" class="form-control" placeholder="Usuário" required>
                                </div>
                                <div class="form-group mb-4">
                                    <label for="password" class="sr-only">Senha</label>
                                    <input type="password" name="password" id="password" class="form-control" placeholder="Senha" required>
                                </div>
                                <input name="login" id="login" class="btn btn-block login-btn mb-4" type="submit" value="Login">
                            </form>
                            <a href="#!" class="forgot-password-link">Esqueceu sua senha?</a>
                            <nav class="login-card-footer-nav">
                                <a href="#!">Terms of use.</a>
                                <a href="#!">Privacy policy</a>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>

<script>
module.exports = {
  data: function () {
    var pin = this.$route.params.pin;
    return {
      onValidation: pin ? true : false,
      identificador: pin ? pinToString(pin) : '',
      acceptedPrivacyPolicy: false,
      alertText: null
    };
  },
  methods: {
      validarIdentificador: function () {
      if (this.$refs.document) {
        var el = this.$refs.document.$el;
        if (!validation.isCPF(this.identificador) && !validation.isCNPJ(this.identificador)) {
          el.setCustomValidity('Digite um CPF/CNPJ válido!');
        } else {
          el.setCustomValidity('');
        }
      }
    },
    login: function () {
        alert(1);
      this.onValidation = true;
    }
  }
}
</script>
