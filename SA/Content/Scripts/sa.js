//Variáveis globais

var qtdestoque = 0;
var dados = new Array();    


/*  
 * Atualiza a grid/tabela com os produtos selecionados 
 */
function AtualizaGrid(dados) {

    var tabela = document.getElementById("tbselecionado");
    var textab = "";
    var classe = "";

    for (var i = 0; i <= dados.length - 1; i++) {

        if (dados[i].QuantidadeEstoque < dados[i].QuantidadeSolicitada) {
            classe = "alert alert-danger";
        } else if (dados[i].QuantidadeEstoque == dados[i].QuantidadeSolicitada) {
            classe = "alert alert-warning";
        } else {
            classe = "";
        }



        textab += "<tr class='" + classe + "' id='trSolicitacao'" + i + ">"
        textab += "<td id='tdProduto'" + i + ">" + dados[i].DescricaoProduto + "</td>"
        textab += "<td id='tdQuantidadeEstoque'" + i + ">" + dados[i].QuantidadeEstoque + "</td>"
        textab += "<td id='tdQuantidadeSolicitada'" + i + ">" + dados[i].QuantidadeSolicitada + "</td>"
        textab += "<td id='tdDepartamento'" + i + ">" + dados[i].Departamento + "</td>"
        textab += "<td id='tdCentrodCusto'" + i + ">" + dados[i].CentroCusto + "</td>"
        textab += "<td id='tdobservacao'" + i + ">" + dados[i].Observacao + "</td>"
        textab += "<td id='tdEdit'" + i + "><span class='glyphicon glyphicon-wrench'></span></td>"
        textab += "<td id='tdEdit'" + i + "><span class='glyphicon glyphicon-trash'></span></td>"
        textab += "</tr>"

    }

    tabela.outerHTML = '<tbody id="tbselecionado">' + textab + '</tbody>';

}




/*
 *  Monta o array com os produtos selecionados 
 */
function AdicionaArray() {
   

    var tipoReq = document.getElementById("tprequisicao");
    var numReq = document.getElementById("numtpr");
    var prd = document.getElementById("produto");
    var prdDesc = prd.value.substring(15, prd.value.length);
    var qtd = document.getElementById("quantidade");
    var qtdEst = qtdestoque;
    var obs = document.getElementById("observacao");
    var dep = document.getElementById("departamento");
    var cc = document.getElementById("centrocusto");
    var obs = document.getElementById("observacao");

    //Verifica se o produto já não foi selecionado
    if (!BuscaProduto(prd.value.substring(0, 15)))
    {
        return;
    }

    //Crio um Item de SA
    var ItemSA = {
        TipoRequisicao: tipoReq[tipoReq.selectedIndex].textContent,
        TipoRequisicaoValor: tipoReq[tipoReq.selectedIndex].value,
        NumeroReq: numReq.value,
        CodigoProduto: prd.value.substring(0, 15),
        DescricaoProduto: prd.value.substring(15, prd.value.length),
        QuantidadeEstoque: qtdEst,
        QuantidadeSolicitada: qtd.value,
        Departamento: dep[dep.selectedIndex].textContent,
        DepartamentoValor: dep[dep.selectedIndex].value,
        CentroCusto: cc.value,
        Observacao: obs.value
    };        

    dados.push(ItemSA);    
    AtualizaGrid(dados);
    ZeraForm();
}




/**
 * Busca se o produto já existe no array de dados
 * @param {any} codprod
 */
function BuscaProduto(codprod)
{
    

    for (var i = 0; i < dados.length; i++) {
        if (dados[i].CodigoProduto == codprod) {

            EscreveAviso("Esse produto já consta na Solicitação");
            return false;
        }

    }
    return true;
}





/**
 * Zera os atributos em tela
 */
function ZeraForm() {

   
   
    var prd = document.getElementById("produto");
    var prdDesc = prd.value.substring(15, prd.value.length);
    var qtd = document.getElementById("quantidade");    
    var obs = document.getElementById("observacao");
    qtdestoque = 0;
    
    prd.value = "";
    qtd.value = "";
    obs.value = "";
    
}




/**
 * Monta a lista de produtos em tela
 * @param {any} response
 */
function MontaListaProduto(response) {
    var listaHtml = "";
    var listaProduto = document.getElementById("lstproduto");
        
    for (var i = 0; i < response.lista.length; i++) {
        var texto = response.lista[i].Codigo + response.lista[i].Descricao.trim();
        listaHtml += "<option value='" + texto + "'>";
    }
    listaProduto.outerHTML = ' <datalist id="lstproduto">' + listaHtml + "</datalist>";
}




function AtualizaEstoque(response) {
    if (response.estoque <= 0) {
        quant.className = "alert alert-danger form-control";
        quant.placeholder = "Saldo Insuficiente: " + response.estoque;
    } else {
        quant.placeholder = "Saldo em Estoque: " + response.estoque;
        quant.className = "form-control";
    }
    qtdestoque = response.estoque;

}



/**
 * Valida se o que foi digitado no campo quantidade é um número
 */
function ValidaQuantidade() {
    var quantidade = parseFloat(document.getElementById("quantidade").value);

    if (!IsNumber(quantidade)) {
        EscreveAviso("O valor que você informou não me parece ser um número");
    }

}




/**
 * Valida se um argumento é um número
 * @param {any} argumento
 */
function IsNumber(argumento) {
    return result = (typeof argumento === 'number' && !isNaN(argumento));
}




/**
 * Escreve o aviso logo após o botão de adicionar
 */
function EscreveAviso(texto) {
var avisos = document.getElementById("avisos");
avisos.outerHTML = '<div id="avisos" class="alert alert-warning">' + texto+'</div>';
}

/**
 * Valida se o centro de custo está preechido
 */
function ValidaCentroCusto() {
    var CentroCusto = document.getElementById("centrocusto").value;

    if (CentroCusto != NaN && CentroCusto.length > 0) {
        return true;
    }
    return false;
}

/**
 * Valida se o produto foi inserido
 */
function ValidaProduto() {
    var produto = document.getElementById("produto").value;

    if (produto != NaN && produto.length > 0 && produto.substring(0,15).length <= 15) {
        return true;
    }

    return false
}



/**
 * Valida se a quatidade foi inserida
 */
function ValidaQuantdInsert() {
    var quantidade = document.getElementById("quantidade").value;

    if (quantidade != NaN && quantidade.length>0) {
        return true;
    }
    return false;

}

/**
 * Faz todas as validações de campo
 */
function TudoValido(){
    if (!ValidaProduto()) {
        EscreveAviso("O código do produto está inválido! Código de produto não existe")
        return false;
    }

    if (!ValidaQuantdInsert()) {
        EscreveAviso("Quantidade não preechida!")
        return false;
    }

    if (!ValidaCentroCusto()) {
        EscreveAviso("Centro de Custo não preechido!")
        return false;
    }

    return true;
}