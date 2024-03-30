<template>
  <MarkdownEditor :title="exampleTitle" :contents="exampleMdContent"/>
</template>

<script setup lang="ts">
import MarkdownEditor from './components/markdown-editor.vue'

const exampleTitle = "Example Title";

const exampleHtmlContent = 
  `<h1> Hello, world!</h1> 

  <b>Lorem ipsum dolor</b> sit amet

  <ul>
    <li> Some</li> 
    <li> Unordered</li> 
    <li> List </li>
  </ul>

  <ol>
    <li> Some </li> 
    <li> Ordered </li>
    <li> List </li>
  </ol> `;

  const exampleMdContent = 
  `# Hello, world!

  **Lorem ipsum dolor** _sit amet_ 
  * Some 
  * Unordered 
  * List 
  
  1. Some 
  1. Ordered
  1. List`;

</script>

<style>

</style>
