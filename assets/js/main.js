$(function(){
	$(".bars").on('click', function(){
		$('header ul').animate({ "width":'200px' }, 100);
		$("header ul").show();
		$(this).hide();
	});
	
	$(".close-colapse, .container").on('click', function(){
		$('header ul').animate({ "width":'0px' }, 100);
		$("header ul").hide();
		$(".bars").show();
	});
});