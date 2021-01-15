var applyCPFMask = function ($content) {
    $content.mask('000.000.000-00', { placeholder: "000.000.000-00" });
}

var applyDateMask = function ($content) {
    $content.mask('99/99/9999', { placeholder: "dia/mês/ano" });
}

var applyMoneyMask = function ($content) {
    $content.mask("#.##0,00", { placeholder: "0,00", reverse: true });
}

var applyPercentMask = function ($content) {
    $content.mask('Z99.99', {
        placeholder: "00.00%",
        translation: { 'Z': { pattern: /[\-\+]/, optional: true } }
    });
}

$(function () { // document.ready

    'use strict';

    var $body = $('body'), // cache DOM
        $maskCPF = $body.find('.cpf'),
        $maskPercent = $body.find('.porcentagem'),
        $maskDate = $body.find('.data'),
        $maskMoney = $body.find('.dinheiro');

    if ($maskCPF.length) { applyCPFMask($maskCPF); }
    if ($maskDate.length) { applyDateMask($maskDate); }
    if ($maskMoney.length) { applyMoneyMask($maskMoney); }
    if ($maskPercent.length) { applyPercentMask($maskPercent); }

    // Formulário 
    if ($body.find("#formAdd").length > 0) {

        var index = 0,
            $btnAddNew = $body.find("#btnAddNew"),
            $boxParcelas = $body.find("#boxParcelas"),
            template = function (index) {

                var html = "<div class='form-row'>";

                html += "<div class='form-group col-md-4'>";
                html += "<label>Número da parcela</label>";
                html += "<input type='text' class='form-control' placeholder='Somente números...' data-val='true' data-val-required='É necessário informar o número.' name='Divida.Parcelas[" + index + "].Numero' />";
                html += "<div class='invalid-feedback' style='display:inline'>";
                html += "<span class='text-danger' data-valmsg-for='Divida.Parcelas[" + index + "].Numero' data-valmsg-replace='true'></span>";
                html += "</div>";
                html += "</div>";

                html += "<div class='form-group col-md-4'>";
                html += "<label>Data de vencimento</label>";
                html += "<input type='text' class='form-control data' data-val='true' data-val-required='É necessário informar a data de vencimento.' name='Divida.Parcelas[" + index + "].DataVencimento' />";
                html += "<div class='invalid-feedback' style='display:inline'>";
                html += "<span class='text-danger' data-valmsg-for='Divida.Parcelas[" + index + "].DataVencimento' data-valmsg-replace='true'></span>";
                html += "</div>";
                html += "</div>";

                html += "<div class='form-group col-md-4'>";
                html += "<label>Valor da parcela</label>";
                html += "<input type='text' class='form-control dinheiro' data-val='true' data-val-required='É necessário informar o valor.' name='Divida.Parcelas[" + index + "].Valor' />";
                html += "<div class='invalid-feedback' style='display:inline'>";
                html += "<span class='text-danger' data-valmsg-for='Divida.Parcelas[" + index + "].Valor' data-valmsg-replace='true'></span>";
                html += "</div>";
                html += "</div>";

                html += "</div>";

                return html;
            };

        $btnAddNew.on("click", function (e) {

            e.preventDefault();

            $boxParcelas.append(template(index));
            applyDateMask($boxParcelas.find(".data"));
            applyMoneyMask($boxParcelas.find(".dinheiro"));
            index++;

        });
    }

});