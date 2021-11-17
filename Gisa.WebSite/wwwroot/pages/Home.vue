<template>
    <div>
        <topbar-menu></topbar-menu>
        <div class="container-fluid">
            <div class="row">
                <sidebar-menu></sidebar-menu>
                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 home-main">
                    <div class="vh-100 home">
                    </div>
                </main>
            </div>
        </div>
    </div>
</template>

<script>
    module.exports = {
        data: function () {
            return {
                contractor: null,
                providers: null,
                alert: null
            };
        },
        methods: {
            save: function () {

            },
            removerAlert: function () {
                this.alert = null;
                clearInterval(this.interval);
            }
        },
        created: function () {
            this.contractor = {
                "id": 0,
                "provider": "",
                "codigoExterno": "",
                "nome": "",
                "peso": "",
                "ativo": ""
            }
        }
    }
</script>