window.addEventListener("load", solve);

function solve() {
   let titleInput = document.getElementById('title');
   let authorInput = document.getElementById('author');
   let summaryInput = document.getElementById('summary');

   let addBtn = document.getElementById('add-btn');
   let draftList = document.getElementById('draft-list');
   let publishedList = document.getElementById('published-list');

   addBtn.addEventListener('click', addArticle);

   function addArticle(e) {
      e.preventDefault();

      let title = titleInput.value;
      let author = authorInput.value;
      let summary = summaryInput.value;

      if (title === '' || author === '' || summary === '') {
         return;
      }

      let li = createDraftArticle(title, author, summary);
      draftList.appendChild(li);

      titleInput.value = '';
      authorInput.value = '';
      summaryInput.value = '';

      addBtn.disabled = true;
   }

   function createDraftArticle(title, author, summary) {
      let li = document.createElement('li');
      li.className = 'post';

      let article = document.createElement('article');

      let titleP = document.createElement('p');
      titleP.textContent = title;

      let authorP = document.createElement('p');
      authorP.textContent = author;

      let summaryP = document.createElement('p');
      summaryP.textContent = summary;

      article.appendChild(titleP);
      article.appendChild(authorP);
      article.appendChild(summaryP);

      let buttonsDiv = document.createElement('div');
      buttonsDiv.className = 'buttons';

      let editBtn = document.createElement('button');
      editBtn.className = 'edit-btn';
      editBtn.textContent = 'Edit';

      let approveBtn = document.createElement('button');
      approveBtn.className = 'approve-btn';
      approveBtn.textContent = 'Approve';

      buttonsDiv.appendChild(editBtn);
      buttonsDiv.appendChild(approveBtn);

      li.appendChild(article);
      li.appendChild(buttonsDiv);

      editBtn.addEventListener('click', function () {
         titleInput.value = title;
         authorInput.value = author;
         summaryInput.value = summary;

         draftList.removeChild(li);
         addBtn.disabled = false;
      });

      approveBtn.addEventListener('click', function () {
         draftList.removeChild(li);
         li.removeChild(buttonsDiv);

         let publishBtn = document.createElement('button');
         publishBtn.className = 'publish-btn';
         publishBtn.textContent = 'Publish';

         li.appendChild(publishBtn);
         publishedList.appendChild(li);

         publishBtn.addEventListener('click', function () {
            publishedList.removeChild(li);
            addBtn.disabled = false;
         });
      });

      return li;
   }
}