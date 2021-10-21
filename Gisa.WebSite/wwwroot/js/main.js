const version = '0.0.7';

function httpVueLoaderAppendVersion(path) {
  return httpVueLoader(path + '?v=' + version);
}

Vue.directive('mask', VueTheMask.mask);
Vue.component('topbar-menu', httpVueLoader('components/TopbarMenu.vue'));
Vue.component('sidebar-menu', httpVueLoader('components/SidebarMenu.vue'));

Vue.filter('money', function (value) {
  if (!value) return '';
  return value.toLocaleString('pt-br', {style: 'currency', currency: 'BRL'});
});


const store = {
  localizerStrings: {},
  lang: 'pt-br',
  supportedLangs: ['pt-br', 'en'],
  moneyMaskOptions: {
    decimal: ',',
    thousands: '.',
    prefix: 'R$ ',
    suffix: '',
    precision: 2,
    masked: false
  }
};


function localizer(key) {
  return store.localizerStrings[key] || key;
}

function stringToPin(str) {
  return parseInt('1' + str.split("").reverse().join("")).toString(36);
}
function pinToString(pin) {
  return parseInt(pin, 36).toString().substring(1).split("").reverse().join("");
}

Vue.mixin({
  data: function () {
    return store;
  },
  methods: {
    localizer: localizer
  }
});

const router = new VueRouter({
  routes: [
        { path: '*', component: httpVueLoaderAppendVersion('pages/Login.vue') },
        { path: '/', component: httpVueLoaderAppendVersion('pages/Login.vue') },
        { path: '/associado', component: httpVueLoader('pages/Associado/Cadastro.vue') },
        { path: '/consultas', component: httpVueLoader('pages/Associado/Consulta.vue') },
        { path: '/exames', component: httpVueLoader('pages/Associado/Exame.vue') },
        { path: '/workflow', component: httpVueLoader('pages/WorkFlow/Cadastro.vue') },
  ]
});

router.beforeEach(function (to, from, next) {
    //debugger;
    //// redirect to login page if not logged in and trying to access a restricted page
    //const publicPages = ['/login'];
    //const authRequired = !publicPages.includes(to.path);
    //const loggedIn = localStorage.getItem('user');

    //if (authRequired && !loggedIn) {
    //    return next('/login');
    //}

    next();
});

const app = new Vue({
  el: '#app',
  router: router,
  methods: {
    loadLang: function (lang) {
      if (lang) {
        store.lang = lang;
      }
      $.get('lang/' + store.lang + '.json').done(function (strings) {
        store.localizerStrings = strings;
      }).fail(function () {
        store.localizerStrings = {};
      });
    }
  },
  created: function () {
    this.loadLang();
  }
});

const acaoEventoEnum = {
    LEAD: 1,
    VALIDACAO_DEVEDOR: 2,
    ATUALIZACAO_CADASTRAL: 3,
    SOLICITACAO_ACESSO_EMAIL: 4,
    SOLICITACAO_ACESSO_SMS: 5,
    CONTRATO: 6,
    CONTATO: 7,
    MOTIVO_SEGUNDA_VIA: 8,
    SELECAO_PROPOSTA: 9,
    ACEITE_PROPOSTA: 10,
    ACEITE_SEGUNDA_VIA: 11,
    CANAL_SEGUNDA_VIA: 12,
    CANAL_BOLETO: 13,
    BOLETO_ENVIADO: 19,
    PESQUISA: 22
}