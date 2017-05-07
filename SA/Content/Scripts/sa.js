

/*  
 * Atualiza a grid/tabela com os produtos selecionados 
 */
function AtualizaGrid(itemSa){

   
    var textab = "";
    var classe = "";
   
       
    if (itemSa.QuantidadeEstoque < itemSa.QuantidadeSolicitada) {
            classe = "alert alert-danger";
        } else if (itemSa.QuantidadeEstoque === itemSa.QuantidadeSolicitada) {
            classe = "alert alert-warning";
        } else {
            classe = "";
        }



        textab += "<tr class='" + classe + "' id='trSolicitacao" + dados.length  +"'>";
        textab += "<td id='tdCodigoProduto" + dados.length+"'>" + itemSa.CodigoProduto + "</td>";
        textab += "<td id='tdProduto'>" + itemSa.DescricaoProduto + "</td>";
        textab += "<td id='tdQuantidadeEstoque'>" + itemSa.QuantidadeEstoque + "</td>";
        textab += "<td id='tdQuantidadeSolicitada'>" + itemSa.QuantidadeSolicitada + "</td>";
        textab += "<td id='tdDepartamento'>" + itemSa.Departamento + "</td>";
        textab += "<td id='tdCentrodCusto'>" + itemSa.CentroCusto + "</td>";
        textab += "<td id='tdobservacao'>" + itemSa.Observacao + "</td>";
        textab += "<td id='tdEdit'><a href='#' onclick='EditaArray(" + dados.length  +")'  ><span class='glyphicon glyphicon-wrench'></span></a></td>";
        textab += "<td id='tdEdit'><a href='#' onclick='SubtraiArray(" + dados.length  +")' ><span class='glyphicon glyphicon-trash'></span></a></td>";
        textab += "</tr>";

        tabela.innerHTML = textab + tabela.innerHTML; 

}


/*
 *  Monta o array com os produtos selecionados 
 */
function AdicionaArray() {

    var qtdEst = qtdestoque;    
    

    //Verifica se o produto já não foi selecionado
    if (!BuscaProduto(prd.value.substring(0, 15)))
    {
        return;
    }

    //Crio um Item de SA
    var ItemSA = {
        TipoRequisicao: tipoReq[tipoReq.selectedIndex].textContent,
        TipoRequisicaoValor: tipoReq[tipoReq.selectedIndex].value,
        NumeroReq: numtpr.value,
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
    AtualizaGrid(ItemSA);
    ZeraForm();
    prd.focus();
}




function EditaArray(posicao) {
    
    var indexJson = posicao - 1;

    numtpr.value    = dados[indexJson].NumeroReq;
    prd.value       = dados[indexJson].CodigoProduto + dados[indexJson].DescricaoProduto;
    qtd.value       = dados[indexJson].QuantidadeSolicitada;
    obs.value       = dados[indexJson].Observacao;
    dep.value       = dados[indexJson].DepartamentoValor;
    cc.value        = dados[indexJson].CentroCusto;


    SubtraiArray(posicao)

}


/**
 * Remove um item da Lista
 * @param {any} posicao
 */
function SubtraiArray(posicao) {
    var trItemSelecionado = document.querySelector("#trSolicitacao" + posicao);

    dados = dados.filter(function (sa) {
        var tdProduto = document.querySelector("#tdCodigoProduto" + posicao);
        return sa.CodigoProduto != tdProduto.textContent;
    })

    trItemSelecionado.innerHTML = "";

}



/**
 * Busca se o produto já existe no array de dados
 * @param {any} codprod
 */
function BuscaProduto(codprod)
{
    

    for (var i = 0; i < dados.length; i++) {
        if (dados[i].CodigoProduto === codprod) {

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
    quant.placeholder = "";
    qtdestoque = 0;    
    prd.value = "";
    qtd.value = "";
    obs.value = "";
    
}


function ReiniciaFormulario(){
    dados = new Array();
    tabela.innerHTML = "";
    quant.placeholder = "";
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
  
        
    for (var i = 0; i < response.lista.length; i++) {
        var texto = response.lista[i].Codigo + response.lista[i].Descricao.trim();
        listaHtml += "<option value='" + texto + "'>";
    }
    listaProduto.innerHTML = ' <datalist id="lstproduto">' + listaHtml + "</datalist>";
}



function SaldoDisponivel(saldoEmEstoque, codigoDoProduto) {
    return saldoEmEstoque - SomaSaldoSelecionado(codigoDoProduto)
}


function SomaSaldoSelecionado(codigoDoProduto) {
    var saldoSelecionado=0;

    for (var posicao = 0; posicao < dados.length; posicao++) {
        if (dados[posicao].CodigoProduto === codigoDoProduto) {
            saldoSelecionado += parseFloat(dados[posicao].QuantidadeSolicitada);
        }
    }
    return saldoSelecionado;
}


function AtualizaEstoque(saldo, codigoDoProduto) {

    var saldoDisponivel = SaldoDisponivel(saldo.estoque, codigoDoProduto);

    if (saldoDisponivel <= 0) {
        quant.className = "alert alert-danger form-control";
        quant.placeholder = "Saldo Disponível: " + saldoDisponivel;
    } else {
        quant.placeholder = "Saldo em Disponível: " + saldoDisponivel;
        quant.className = "form-control";
    }
    qtdestoque = saldo.estoque;

}





/**
 * Escreve o aviso logo após o botão de adicionar
 * @param texto
 */
function EscreveAviso(texto) {    
    avisos.innerHTML = '<div id="avisos" class="alert alert-warning">' + texto+'</div>';
}


function LimpaAviso() {
    avisos.innerHTML = '<div id="avisos"></div>';
}



function AvisoModalErro(titulo,texto) {
    modalTitulo.innerHTML = titulo;
    modalTexto.innerHTML = texto;

    $('#avisoModalErro').modal('show');    
}


function AvisoModalSucess(titulo, texto) {
    var modalTiTuloSucess = document.querySelector("#moda_sucess_title");
    var modalBodySucess = document.querySelector("#moda_sucess_body");

    modalTiTuloSucess.innerHTML = titulo;
    modalBodySucess.innerHTML = texto;

    $('#avisoModalSucesso').modal('show');
}

function SolicitacaoGravada(numeroDaSolicitacao,url) {
    ReiniciaFormulario();

    AvisoModalSucess("Solicitação gravada com sucesso", "Solicitação Criada :" + numeroDaSolicitacao);

    setTimeout(function () {
        //var url = "@Url.Action("Index", "Home")";
        window.location.replace(url);
    }, 3000);
}