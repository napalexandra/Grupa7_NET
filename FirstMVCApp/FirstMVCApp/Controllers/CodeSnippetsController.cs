﻿using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _codeSnippetsRepository;

        public CodeSnippetsController(CodeSnippetsRepository codeSnippetsRepository)
        {
            _codeSnippetsRepository = codeSnippetsRepository;
        }

        // GET: CodeSnippetsController
        public ActionResult Index()
        {
            var codeSnippets = _codeSnippetsRepository.GetCodeSnippets();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippetsController/Details/5
        public ActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippet = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Details", codeSnippet);
        }

        // GET: CodeSnippetsController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CodeSnippetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            TryUpdateModelAsync(codeSnippetModel);   //mapam formularul pe model
            _codeSnippetsRepository.AddCodeSnippet(codeSnippetModel);
            return RedirectToAction("Index");
        }

        // GET: CodeSnippetsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Edit", codeSnippetModel);
        }

        // POST: CodeSnippetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            TryUpdateModelAsync(codeSnippetModel);
            _codeSnippetsRepository.UpdateCodeSnippet(codeSnippetModel);
            return RedirectToAction("Index");
        }

        // GET: CodeSnippetsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Delete", codeSnippetModel);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _codeSnippetsRepository.DeleteCodeSnippet(id);
            return RedirectToAction("Index");
        }
    }
}
