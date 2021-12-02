<template>
    <div>
        <topbar-menu></topbar-menu>
        <div class="container-fluid">
            <div class="row">
                <sidebar-menu></sidebar-menu>
                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
                    <div class="pb-4">
                        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                            <h1 class="h2">Consultas</h1>
                            <div class="btn-toolbar mb-2 mb-md-0">
                                <router-link to="/consultaagendar" class="btn btn-sm btn-primary">
                                    <i class="icon-plus-circle "></i>
                                    Agendar consulta
                                </router-link>
                            </div>
                        </div>
                        <div class="card mt-3" v-for="consulta in consultas">
                            <div class="card-header">
                                <h5 class="card-title">{{consulta.especialidade.nome}} - {{consulta.agendamento | formatDate}}</h5>
                            </div>
                            <div class="card-body">
                                <p class="card-text"><b>Conveniado:</b> {{consulta.conveniado.nome}}</p>
                                <p class="card-text" v-if="consulta.prestador">Prestador: {{consulta.prestador.nome}}</p>
                                <p class="card-text">
                                    <b>Endere&ccedil;o:</b> {{consulta.conveniado.endereco.logradouro}}, {{consulta.conveniado.endereco.numero}}  {{consulta.conveniado.endereco.complemento}} <br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    {{consulta.conveniado.endereco.bairro}} - {{consulta.conveniado.endereco.cep}}<br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    {{consulta.conveniado.endereco.cidade}} - {{consulta.conveniado.endereco.estado}}
                                    <div class="pin" onclick="alert(1);"></div>
                                </p>
                                <h5 class="card-title">Status: Em agendamento</h5>
                                <br />
                                <ul class="timeline" id="timeline">
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4>Pedido solicitado</h4>
                                        </div>
                                    </li>
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4>Aprova&ccedil;&atilde;o m&eacute;dica</h4>
                                        </div>
                                    </li>
                                    <li class="li wait">
                                        <div class="timestamp">
                                            <span class="date">&nbsp;</span>
                                        </div>
                                        <div class="status">
                                            <h4> Agendamento </h4>
                                        </div>
                                    </li>
                                    <li class="li">
                                        <div class="timestamp">
                                            <span class="date">&nbsp;</span>
                                        </div>
                                        <div class="status">
                                            <h4> Autorizado </h4>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <br />
                        <div class="card">
                            <div class="card-header">
                                Exame cl&iacute;nico
                            </div>
                            <div class="card-body">
                                <p class="card-text">Exames solicitados: Hemograma/Colesterol/Triglicer&iacute;deos/Eletr&oacute;litos</p>
                                <p class="card-text">Laborat&oacute;rio: Delboni Santo Andr&eacute;</p>
                                <h5 class="card-title">Status da solicita&ccedil;&atilde;o: Em agendamento</h5>
                                <br />
                                <ul class="timeline" id="timeline">
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4>Pedido solicitado</h4>
                                        </div>
                                    </li>
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4>Aprova&ccedil;&atilde;o m&eacute;dica</h4>
                                        </div>
                                    </li>
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4> Agendamento </h4>
                                        </div>
                                    </li>
                                    <li class="li complete">
                                        <div class="timestamp">
                                            <span class="date">11/15/2014 11:02</span>
                                        </div>
                                        <div class="status">
                                            <h4> Autorizado </h4>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
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
                consultas:[]
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
            this.loading = true;
            api.ConsultaRecuperarRecuperar().then((data) => {
                console.log(data);
                this.consultas = data;
            });
        }
    }
</script>