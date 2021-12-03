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
                                    <button type="button" @click="filtrar" class="btn btn-sm btn-primary">
                                        Filtrar
                                    </button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Tipo</label>
                                    <div class="input-group">
                                        <select v-model="filtro.conveniadoTipo" class="custom-select d-block" @change="recuperarEspecialidades()" required>
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
                                        <select v-model="filtro.especialidade" class="custom-select d-block" :disabled="filtro.conveniadoTipo == ''" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option v-for="item in especialidades" :value="item.identificador">
                                                {{item.nome}}
                                            </option>
                                        </select>
                                        <div v-if="!especialidades" class="input-group-append">
                                            <span class="input-group-text">
                                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Estado</label>
                                    <div class="input-group">
                                        <select v-model="filtro.estado" class="custom-select d-block" @change="recuperarCidades()" :disabled="filtro.especialidade == ''" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option v-for="item in estados" :value="item">
                                                {{item}}
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Cidade</label>
                                    <div class="input-group">
                                        <select v-model="filtro.cidade" class="custom-select d-block" :disabled="filtro.estado == ''" required>
                                            <option value="">{{localizer('Choose')}}...</option>
                                            <option v-for="item in cidades" :value="item">
                                                {{item}}
                                            </option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="card mt-3" v-for="conveniado in conveniados">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-10">
                                    <h5 class="card-title">{{conveniado.nome}}</h5>
                                </div>
                                <div class="col-md-2">
                                    <button type="button" class="btn btn-sm btn-primary float-right" data-toggle="modal" data-target="#parametroModal" @click="popup(conveniado)">
                                        <i class="icon-calendar"></i>&nbspAgendar
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <p class="card-text">
                                <b>Endere&ccedil;o:</b> {{conveniado.endereco.logradouro}}, {{conveniado.endereco.numero}}  {{conveniado.endereco.complemento}} <br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                {{conveniado.endereco.bairro}} - {{conveniado.endereco.cep}}<br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                {{conveniado.endereco.cidade}} - {{conveniado.endereco.estado}}
                            </p>
                        </div>
                    </div>
                </main>

                <div>
                    <div class="modal fade" id="parametroModal" tabindex="-1" role="dialog">
                        <div class="modal-dialog modal-dialog-centered modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5>Agendamento em {{conveniado.nome}}</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <label>Data agendamento</label>
                                    <div class="date form_datetime">
                                        <input size="16" type="text" class="dateTimeCustom" value="" readonly>
                                        <span class="add-on dateTimeCustomButton"><i class="icon-calendar"></i></span>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" data-dismiss="modal" class="btn btn-sm btn-outline-secondary">Cancelar</button>
                                    <button type="button" class="btn btn-sm btn-primary">Salvar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

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
                especialidades: [],
                estados: [],
                cidades: [],
                filtro: { "conveniadoTipo": '', "especialidade": '', "estado": '', "cidade": '' },
                conveniados: [],
                conveniado: {"nome": ""},
                alert: null
            };
        },
        methods: {
            save: function () {

            },
            popup: function (objeto) {
                this.conveniado = objeto;
            },
            recuperarEspecialidades: function () {
                if (this.filtro.conveniadoTipo !== '') {
                    api.EspecialidadesRecuperarPorTipoConveniado(this.filtro.conveniadoTipo).then((data) => {
                        this.especialidades = data;
                    }, (error) => {
                        alert(error.responseText);
                    });
                }
                else {
                    this.filtro.especialidade = '';
                    this.filtro.estado = '';
                    this.filtro.cidade = '';
                }
            },
            recuperarCidades: function () {
                if (this.filtro.estado !== '') {
                    api.CidadesRecuperar(this.filtro.estado).then((data) => {
                        this.cidades = data;
                    }, (error) => {
                        alert(error.responseText);
                    });
                }
                else
                    this.filtro.cidade = '';
            },
            filtrar: function () {
                api.ConveniadosFiltrar('', this.filtro.conveniadoTipo, this.filtro.especialidade, this.filtro.estado, this.filtro.cidade).then((data) => {
                    this.conveniados = data;
                    console.log(this.conveniados);
                    if (this.conveniados == null)
                        Command: toastr["info"]("Não foram encontrados conveniados");
                }, (error) => {
                    Command: toastr["danger"](error.responseText);
                });
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
            };
            api.EstadosRecuperar().then((data) => {
                this.estados = data;
            }, (error) => {
                alert(error.responseText);
            });
        }
    }
</script>