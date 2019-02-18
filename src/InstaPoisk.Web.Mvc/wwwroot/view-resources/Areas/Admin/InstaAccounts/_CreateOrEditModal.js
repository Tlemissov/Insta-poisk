(function ($) {

	var _service = abp.services.app.instaAccount;
	var _referenceService = abp.services.app.reference;
	var _$modal = $('#CreateOrEditModal');
	var _$form = $('form[name=CreateOrEditModal]');
	var id = $('#ItemId').val();

	$('.selectpicker').selectpicker();


	$('#CategoryId').on('change', function () {
		var id = ($(this).find(":selected").val());
		$(this).val('Mustard');
		$(this).selectpicker('render');
		_referenceService.getSubCategoryType(id).done(function (data) {
			for (var i = 0; i < data.length; i++) {
				//var item = $('<option value="' + data[i].id + '">' + data[i].name + '</option>');
				//$('#SubList').append(item);
				$('#SubList').selectpicker('val', 'Mustard');
			}
			$('#SubList').prop('disabled', false);
			$('#SubList').selectpicker('val', 'Mustard');
			$('#SubList').selectpicker('refresh');

			
		});

	});




    function save() {

        if (!_$form.valid()) {
            return;
        }

        var item = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        item.subItems = $('#SubList').val();
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