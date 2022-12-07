function BuscarCEP(cep) {
    $.ajax({
        url: 'http://api.postmon.com.br/v1/cep/' + cep,
        dataType: "jsonp",
        crossDomain: true,
        success: function(data) {
            $('#Endereco').val(data.logradouro);
            $('#Bairro').val(data.bairro);
            $('#Cidade').val(data.cidade);
            $('#Estado').val(data.estado)
        }

    });
}