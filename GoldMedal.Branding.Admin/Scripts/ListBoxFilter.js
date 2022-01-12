
$(document).ready(function () {
    JSFilter();
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(JSFilter);
});

function JSFilter() {
    if ($('table').find('JS-Filter') !== undefined) {

        var c = $("table[JS-Filter]");

        $(c).each(function () {

            if ($(this).attr('JS-Filter') == 'True') {

                var id = $(this).attr('id');
                var parCtrl = $(this).parent();
                var dialog;
                var wd = $(this).css('width');

                var div1 = document.createElement("div");
                div1.className = "js-filter-container-div";
                div1.style.width = wd;
                div1.style.border = "1px solid #cccccc";
                div1.style.overflow = "hidden";

                var div2 = document.createElement("div");
                div2.className = "js-filter-chkbx-container-div col-md-12";
                div2.style.width = wd;
                div2.style.overflow = "hidden";

                var div3 = document.createElement("div");
                div3.className = "col-md-6";

                var div4 = document.createElement("div");
                div4.className = "col-md-6";

                dialog = document.createElement('input');
                dialog.type = 'text';
                dialog.className = 'form-control JS-Search-txt';
                dialog.style = 'width:' + wd + '; margin: 0; padding: 0;';

                var checkbox = document.createElement('input');
                checkbox.type = "checkbox";
                checkbox.name = "chk-sel-all-js";
                checkbox.id = "chk-sel-all-js";
                checkbox.className = "dxeListBoxItem_Glass dxeC";

                var label = document.createElement('label')
                label.htmlFor = checkbox.id;
                label.appendChild(document.createTextNode('Select All/Filtered'));
                label.className = "dxeListBoxItem_Glass dxeT";
                label.onclick = function (e) {
                    e.preventDefault();
                }


                var checkbox1 = document.createElement('input');
                checkbox1.type = "checkbox";
                checkbox1.name = "chk-unsel-all-js";
                checkbox1.id = "chk-unsel-all-js";
                checkbox1.className = "dxeListBoxItem_Glass dxeC";

                var label1 = document.createElement('label')
                label1.htmlFor = checkbox1.id;
                label1.appendChild(document.createTextNode('Unselect All/Filtered'));
                label1.className = "dxeListBoxItem_Glass dxeT";
                label1.onclick = function (e) {
                    e.preventDefault();
                }


             
                //if ($(parCtrl.prev().hasClass('JS-Search-txt') == false)) {
                if ($(parCtrl).prev().find('input').hasClass('JS-Search-txt') == false) {
                    $(div1).insertBefore($(parCtrl));

                    $(dialog).appendTo($(parCtrl).closest(":has(div.js-filter-container-div)").find('.js-filter-container-div'));
                    $(div2).appendTo($(parCtrl).closest(":has(div.js-filter-container-div)").find('.js-filter-container-div'));

                    $(div3).appendTo(div2);
                    $(div4).appendTo(div2);

                    $(checkbox).appendTo(div3);
                    $(label).appendTo(div3);

                    $(checkbox1).appendTo(div4);
                    $(label1).appendTo(div4);

                }

            }

        });
    }

    $('.JS-Search-txt').keyup(function (event) {
   
        $(this).next().find('input[type="checkbox"]').prop('checked', false);
        if ($(this).val().trim() != '') {

            var sRt = $(this).val().trim();

            $(this).parent().next().find('.js-filter-class').find('table:visible').find('tr').each(function (i) {

                if ($(this).find('td:nth-child(2)').text().toLowerCase().indexOf(sRt.toLowerCase()) > -1) {
                    $(this).css('display', 'block');
                }
                else {
                    $(this).css('display', 'none');
                }

            });
            $('.js-filter-class').find('tbody').find('tr').find("td").find("div").find('div').css({ 'height': 'auto' })
        }
        else {

            $(this).parent().next().find('.js-filter-class').find('table:visible').find('tr').css('display', 'block');
        }
       
    });


    $('[id$=chk-sel-all-js]').change(function (event) {
        if ($(this).prop('checked') == true) {

            
            var ctrl = eval($(this).closest(":has(div.js-filter-container-div)").find('.js-filter-class').attr('id').split('_'));
            var ctrlE = $(ctrl).last()[0];
            var ctrlF = eval(ctrlE);
            
            var Chkarr = [];
            
            var sRt = $('#chk-sel-all-js').parent().parent().prev().val().trim();

            if (sRt != '') {
                for (var i = 0; i < ctrlF.GetItemCount() ; i++) {
                    

                    var itm = ctrlF.GetItem(i);
                    
                    if (itm.text.toLowerCase().indexOf(sRt.toLowerCase()) > -1) {
                        Chkarr.push(i);
                    }
                }

                ctrlF.SelectIndices(Chkarr);
            }
            else {
                ctrlF.SelectAll();
                $('[id$=chk-unsel-all-js]').prop('checked', false);
            }

            Chkarr = [];
        }

    });


    $('[id$=chk-unsel-all-js]').change(function (event) {
        if ($(this).prop('checked') == true) {

            var ctrl = eval($(this).closest(":has(div.js-filter-container-div)").find('.js-filter-class').attr('id').split('_'));
            var ctrlE = $(ctrl).last()[0];
            var ctrlF = eval(ctrlE);

            var Chkarr = [];
            
            var sRt = $('#chk-unsel-all-js').parent().parent().prev().val().trim();

            if (sRt != '') {
                for (var i = 0; i < ctrlF.GetItemCount() ; i++) {
                    

                    var itm = ctrlF.GetItem(i);
                    
                    if (itm.text.toLowerCase().indexOf(sRt.toLowerCase()) > -1) {
                        Chkarr.push(i);
                    }
                }

                ctrlF.UnselectIndices(Chkarr);
            }
            else {
                ctrlF.UnselectAll();
                $('[id$=chk-sel-all-js]').prop('checked', false);
            }

            Chkarr = [];
        }

    });

}