window.requestAnimFrame = (function(){
  return  function( callback ){
            window.setTimeout(callback, 1000);
          };
})();

$(document).ready(function(){
  window.setTimeout(function() {
    $('#boxShadow').css('pointer-events', 'all');
    $('#boxShadow').animate({
      opacity: 1
    }, 3000);
  }, 2000);
   
  var $shadow = $('#shadow');
  var $boxShadow = $('#boxShadow');
  var shadowLimit = 200;
  var moveEvent = ('ontouchstart' in document.documentElement) ? "touchmove" : "mousemove";
  
  (function animloop(){
    requestAnimFrame(animloop);
      
    $(window).bind(moveEvent, function(ev){
      var $this = $(this);
      var w      = $this.width();
      var h      = $this.height();
      var center = { x: w/2, y: h/2 };
    
      var evX = (moveEvent == 'touchmove') ? ev.originalEvent.touches[0].clientX : ev.clientX;
      var evY = (moveEvent == 'touchmove') ? ev.originalEvent.touches[0].clientY : ev.clientY;
      
      var shadowX = (center.x - evX) / 10;
      var shadowY = (center.y - evY) / 10;
      
      shadowX = (shadowX > shadowLimit) ? shadowLimit : shadowX;
      shadowX = (shadowX < shadowLimit*-1) ? shadowLimit*-1 : shadowX;
      shadowY = (shadowY > shadowLimit) ? shadowLimit : shadowY;
      shadowY = (shadowY < shadowLimit*-1) ? shadowLimit*-1 : shadowY;
      
      $shadow.css({ textShadow: Math.ceil(shadowX) + 'px '+ Math.ceil(shadowY) +'px '+ Math.abs(shadowX*shadowY)/100 +'px rgba(0,0,0,0.4)' });
      $boxShadow.css({ boxShadow: Math.ceil(shadowX) + 'px '+ Math.ceil(shadowY) +'px '+ Math.abs(shadowX*shadowY)/100 +'px rgba(0,0,0,0.4)' });
   });
  })();


  $('#boxShadow').bind('click', function(){ 
    $('body').animate({
      backgroundColor: '#000000',
    }, 2250);
    $('h1').animate({
      color: '#cc0000'
    }, 2250);
    $('#title').animate({
      top: 0,
      marginTop: -50
    }, 2250);
    $(this).animate({
      opacity: 0
    }, 2250)
    window.setTimeout(function() {
      $('#title').css('position', 'relative');
      $('#boxShadow').css('display', 'none');
      $('#title').css('margin-left', '6px'); // weird offset glitch.
      $('#content').css('display', 'block');
      $('body').css('cursor', 'auto');
      document.getElementById('shadow').removeAttr('shadow');
    }, 2250);
  });

}); 