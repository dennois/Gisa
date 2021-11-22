<template>
    <div>
        <topbar-menu></topbar-menu>
        <div class="container-fluid">
            <div class="row">
                <sidebar-menu></sidebar-menu>
                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
                    <div class="pb-4">
                        <form class="needs-validation" @submit.prevent="save()">
                            <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                                <h1 class="h2">Consulta Agendar</h1>
                                <div class="btn-toolbar mb-2 mb-md-0">
                                    <button type="submit" class="btn btn-sm btn-primary">
                                        Agendar
                                    </button>
                                    <button type="submit" class="btn btn-sm btn-primary">
                                        Agendar
                                    </button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Tipo</label>
                                    <div class="input-group">
                                        <select v-model="contractor.provider" class="custom-select d-block" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option v-for="tipo in ConveniadoTipo" :value="tipo.Tipo">
                                                {{tipo.Nome}}
                                            </option>
                                        </select>
                                        <div v-if="!ConveniadoTipo" class="input-group-append">
                                            <span class="input-group-text">
                                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Especialidade</label>
                                    <div class="input-group">
                                        <select v-model="contractor.provider" class="custom-select d-block" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option v-for="provider in providers" :value="provider.id">
                                                {{provider.alias}}
                                            </option>
                                        </select>
                                        <div v-if="!providers" class="input-group-append">
                                            <span class="input-group-text">
                                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>{{localizer('status')}}</label>
                                    <div class="input-group">
                                        <select v-model="contractor.ativo" class="custom-select d-block" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option value="true">{{localizer('active')}}</option>
                                            <option value="false">{{localizer('inactive')}}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </form>
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
                ConveniadoTipo: 
                    [{ "Nome": "Clinica", "Tipo": "C" }, { "Nome": "Hospital", "Tipo": "H" }, { "Nome": "Laboratorio", "Tipo": "Q" }],
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
            api.EspecialidadesRecuperar('8888').then((data) => {
                debugger;
            }, (error) => {
                alert(error.responseText);
            });
        }
    }
</script>