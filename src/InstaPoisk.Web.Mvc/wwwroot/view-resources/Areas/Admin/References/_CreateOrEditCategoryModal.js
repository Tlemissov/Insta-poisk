(function ($) {

    var _service = abp.services.app.reference;
	var _$modal = $('#CreateOrEditModal');
	var _$form = $('form[name=CreateOrEditModal]');
	var id = $('#ItemId').val();

	$('.selectpicker').selectpicker();

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var item = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        item.List = $('#SubList').val();
		abp.ui.setBusy(_$form);

		(id === '0' ? _service.create : _service.update)(item).done(function () {
			_$modal.modal('hide');
			location.reload(true); //reload page to see edited user!
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);