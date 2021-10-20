<template>
    <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse" v-if="exibir">
        <div class="sidebar-sticky pt-0">
            <ul class="nav flex-column">
                <li class="nav-item">
                    <a class="nav-link collapsed text-truncate" href="#submenuReport" data-toggle="collapse" data-target="#submenuAdministrative">
                        <i class="icon-users"></i>
                        Dados cadatrais
                    </a>
                </li>
            </ul>
            <ul class="flex-column pl-2 nav">
                <li class="nav-item">
                    <router-link to="/Workflow" class="nav-link">
                        <i class="icon-users"></i>
                        Workflow
                    </router-link>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
    module.exports = {
        data: function () {
            return {
                reports: [
                    { path: '/reports/sent-messages', title: 'SentMessages' },
                    { path: '/reports/received-messages', title: 'ReceivedMessages' },
                    { path: '/reports/brokers', title: 'Brokers' },
                    { path: '/reports/cost-center', title: 'CostCenters' },
                ],
                exibir: true
            };
        },
        computed: {
            reportsOrdered: function () {
                return this.reports.sort(function (a, b) {
                    if (localizer(a.title) < localizer(b.title)) return -1;
                    if (localizer(a.title) > localizer(b.title)) return 1;
                    return 0;
                });
            }
        },
        created: function () {
           // this.exibir = localStorage.getItem("autenticado");
        }
    }
</script>
