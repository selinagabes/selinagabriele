function setActive() {
  aObj = document.getElementById('nav').getElementsByTagName('a');
  for(i=0;i<aObj.length;i++) { 
    if(document.location.href.localeCompare(aObj[i].href)===0) {
      aObj[i].parentElement.className='active';
    } else {
        aObj[i].parentElement.className = '';
    }
  }
}

window.onload = setActive;