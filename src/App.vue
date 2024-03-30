<template>
  <MarkdownEditor :title="exampleTitle" :contents="exampleMdContent"/>
</template>

<script setup lang="ts">
import MarkdownEditor from './components/markdown-editor.vue'

const exampleTitle = "Example Title";

const exampleMdContent = 
`# This is a heading

---

**This is bold** | _This is italic_

List 1
* Some 
* Unordered 
* List 

List 2
1. Some 
1. Ordered
1. List

List 3
- [ ] Some
- [X] Task
- [ ] List 

:satellite:

This is a table
| Column 1 | Column 2 |
| -------- | -------- |
| Row 1    | Row 2    |

\`This is inline code\`

\`\`\`
public static void main() 
{
  This is a Code Block
}
\`\`\`

[This is a link](https://www.google.com)

> This is a blockquote...
`;

</script>

<style>

</style>
