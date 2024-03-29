<template>
  <h2
      @input="onTitleInput"
      v-html="documentTitle"
      contenteditable="true"
  />
  <div class="flex flex-wrap">
    <button @click="applyBold" class="button">
      <i class="bi bi-type-bold" />
    </button>
    <button @click="applyItalics" class="button">
      <i class="bi bi-type-italic" />
    </button>
    <button @click="applyHeading1" class="button">
      <i class="bi bi-type-h1" />
    </button>
    <button @click="applyHeading2" class="button">
      <i class="bi bi-type-h2" />
    </button>
    <button @click="applyHeading3" class="button">
      <i class="bi bi-type-h3" />
    </button>
    <button @click="applyHeading4" class="button">
      <i class="bi bi-type-h4" />
    </button>
    <button @click="applyHeading5" class="button">
      <i class="bi bi-type-h5" />
    </button>
    <button @click="applyHeading6" class="button">
      <i class="bi bi-type-h6" />
    </button>
    <button @click="applyUnorderedList" class="button">
      <i class="bi bi-list-ul" />
    </button>
    <button @click="applyOrderedList" class="button">
      <i class="bi bi-list-ol" />
    </button>
    <button @click="applyChecklist" class="button">
      <i class="bi bi-check2-square" />
    </button>
    <button @click="insertHorizontalRule" class="button">
      <i class="bi bi-hr" />
    </button>
    <button @click="insertImage" class="button">
      <i class="bi bi-card-image" />
    </button>
    <button @click="insertHyperlink('')" class="button">
      <i class="bi bi-link" />
    </button>
    <button @click="undo" class="button">
      <i class="bi bi-arrow-counterclockwise" />
    </button>
    <button @click="redo" class="button">
      <i class="bi bi-arrow-clockwise" />
    </button>
    <div
      @input="onDocumentInput"
      v-html="documentContents"
      contenteditable="true"
      class="border border-primary rounded p-2"
      style="white-space:pre-wrap;"
    />
  </div>
</template>

<script lang="ts">
import "bootstrap-icons/font/bootstrap-icons.css";

export default {
  name: "MarkdownEditor",

  props: ["contents", "title"],

  data() {
    return {
      documentContents: this.contents || '<p><br></p>',
      documentTitle: this.title || "Untitled"
    };
  },

  methods: {
    onTitleInput(event) {
      this.$emit("input", event.target.documentTitle);
    },
    onDocumentInput(event) {
      this.$emit("input", event.target.documentContents);
    },
    applyBold() {
      document.execCommand('bold')
    },
    applyItalics() {
      document.execCommand('italic')
    },
    applyHeading1() {
      document.execCommand('formatBlock', false, '<h1>')
    },
    applyHeading2() {
      document.execCommand('formatBlock', false, '<h2>')
    },
    applyHeading3() {
      document.execCommand('formatBlock', false, '<h3>')
    },
    applyHeading4() {
      document.execCommand('formatBlock', false, '<h4>')
    },
    applyHeading5() {
      document.execCommand('formatBlock', false, '<h5>')
    },
    applyHeading6() {
      document.execCommand('formatBlock', false, '<h6>')
    },
    applyUnorderedList() {
      document.execCommand('insertUnorderedList')
    },
    applyOrderedList() {
      document.execCommand('insertOrderedList')
    },
    applyChecklist() {

    },
    insertHorizontalRule() {
      document.execCommand('insertHorizontalRule')
    },
    insertHyperlink(url : string) {
      document.execCommand('createLink')
      // document.execCommand('createLink', false, url)
    },
    insertImage() {
      document.execCommand('insertImage')
    },
    undo() {
      document.execCommand('undo')
    },
    redo() {
      document.execCommand('redo')
    }
  },
};
</script>

<style>
.button {
  @apply border-2;
  @apply border-gray-300;
  @apply rounded-lg;
  @apply px-3 py-1;
  @apply mb-3 mr-3;
}

.button:hover {
  @apply border-green-300;
}
</style>
