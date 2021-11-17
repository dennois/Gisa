const api = {
	getToken: function () {
		return new Promise(function (resolve, reject) {
			var token = localStorage.getItem('access_token');
			if (token) {
				resolve(token);
				return;
			}
			$.ajax({
				type: "GET",
				url: getAccessTokenUrl,
				dataType: "json"
			}).done(function (response) {
				localStorage.setItem('access_token', response.accessToken);
				resolve(response);
			}).fail(reject);
		});
	},
	ajaxWithToken: function (options) {
		return new Promise((resolve, reject) => {
			this.getToken().then(function (token) {
				options.beforeSend = function (xhr) {
					xhr.setRequestHeader('Authorization', 'Bearer ' + token);
				};
				$.ajax(options).done(resolve).fail(reject);
			}).catch(reject);
		});
	},
	ajaxWithCallWebApi: function (options) {
		return new Promise((resolve, reject) => {
			var httpRequestViewModel = {
				method: options.type,
				requestUri: options.url
			};
			if (options.data) {
				httpRequestViewModel.content = JSON.parse(options.data);
			}
			$.ajax({
				method: 'POST',
				url: callWebApiUrl,
				contentType: "application/json",
				data: JSON.stringify(httpRequestViewModel)
			}).done(resolve).fail(reject);
		});
	},
	ajax: function (options) {
		return this.ajaxWithCallWebApi(options);
	},
	ajaxOrDefault: function (options, defaultData) {
		return new Promise((resolve, reject) => {
			this.ajax(options).then(data => resolve(data || defaultData)).catch(reject);
		});
	},
	Login: function (usuario, senha) {
		return $.ajax({
			url: webApiUrl + "/api/login/login/",
			type: "POST",
			contentType: "application/json",
			data: JSON.stringify({
				Login: usuario,
				Senha: senha
			})
		});
	},
	EspecialidadesRecuperar: function (tipo) {
		return $.ajax({
			url: webApiUrl + "/api/especialidade",
			type: "Get",
			headers: { "Authorization": 'Bearer ' + localStorage.getItem('token') }
		});
	}
};
