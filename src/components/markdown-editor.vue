<template>
  <h2 @input="onTitleInput" v-html="documentTitle" contenteditable="true" />
  <div id="toolbar" class="flex flex-wrap">
    <button @click="applyBold" class="button" data-toggle="tooltip" data-placement="top" title="Bold">
      <i class="bi bi-type-bold" />
    </button>
    <button @click="applyItalic" class="button" data-toggle="tooltip" data-placement="top" title="Italic">
      <i class="bi bi-type-italic" />
    </button>

    <div class="dropdown">
      <button class="button dropbutton" data-toggle="tooltip" data-placement="top" title="Headings">
        <i class="bi bi-card-heading"></i>
      </button>

      <div class="dropdown-content">
        <button @click="applyHeading1" class="button" data-toggle="tooltip" data-placement="top" title="Heading 1">
          <i class="bi bi-type-h1" />
        </button>
        <button @click="applyHeading2" class="button" data-toggle="tooltip" data-placement="top" title="Heading 2">
          <i class="bi bi-type-h2" />
        </button>
        <button @click="applyHeading3" class="button" data-toggle="tooltip" data-placement="top" title="Heading 3">
          <i class="bi bi-type-h3" />
        </button>
        <button @click="applyHeading4" class="button" data-toggle="tooltip" data-placement="top" title="Heading 4">
          <i class="bi bi-type-h4" />
        </button>
        <button @click="applyHeading5" class="button" data-toggle="tooltip" data-placement="top" title="Heading 5">
          <i class="bi bi-type-h5" />
        </button>
        <button @click="applyHeading6" class="button" data-toggle="tooltip" data-placement="top" title="Heading 6">
          <i class="bi bi-type-h6" />
        </button>
      </div>
    </div>

    <button @click="applyUnorderedList" class="button" data-toggle="tooltip" data-placement="top" title="Unordered List">
      <i class="bi bi-list-ul" />
    </button>
    <button @click="applyOrderedList" class="button" data-toggle="tooltip" data-placement="top" title="Ordered List">
      <i class="bi bi-list-ol" />
    </button>
    <button @click="applyChecklist" class="button" data-toggle="tooltip" data-placement="top" title="Checklist">
      <i class="bi bi-list-task" />
    </button>
    <button @click="insertHorizontalRule" class="button" data-toggle="tooltip" data-placement="top" title="Horizontal Rule">
      <i class="bi bi-hr" />
    </button>
    <button @click="insertImage" class="button" data-toggle="tooltip" data-placement="top" title="Insert Image">
      <i class="bi bi-card-image" />
    </button>
    <button @click="" class="button" data-toggle="tooltip" data-placement="top" title="Insert Link">
      <i class="bi bi-link" />
    </button>
    <button @click="undo" class="button" data-toggle="tooltip" data-placement="top" title="Undo">
      <i class="bi bi-arrow-counterclockwise" />
    </button>
    <button @click="redo" class="button" data-toggle="tooltip" data-placement="top" title="Redo">
      <i class="bi bi-arrow-clockwise" />
    </button>
    <div
      @input="onDocumentInput"
      v-html="documentContents"
      contenteditable="true"
      class="border border-primary rounded p-2"
      style="white-space: pre-wrap"
    />
  </div>
</template>

<script lang="ts">
import { ref } from 'vue'

import "bootstrap-icons/font/bootstrap-icons.css";



export default {
  name: "MarkdownEditor",
  props: {
    contents: {
      type: String,
      required: true,
    },
    title: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      documentContents: this.contents || "<p><br></p>",
      documentTitle: this.title || "Untitled"
    };
  },
  methods: {
    onTitleInput(event) {
      console.log(typeof event);
      this.$emit("input", event.target.documentTitle);
    },
    onDocumentInput(event) {
      this.$emit("input", event.target.documentContents);
    },

    // Note: execCommand is deprecated, but research indicates that there isn't anything adequate to replace it.
    // Several sources suggested continuing using it because of that. It would be more of an issue if the app wasn't using electron.
    applyBold() {
      document.execCommand("bold");
    },
    applyItalic() {
      document.execCommand("italic");
    },
    applyHeading1() {
      document.execCommand("formatBlock", false, "<h1>");
    },
    applyHeading2() {
      document.execCommand("formatBlock", false, "<h2>");
    },
    applyHeading3() {
      document.execCommand("formatBlock", false, "<h3>");
    },
    applyHeading4() {
      document.execCommand("formatBlock", false, "<h4>");
    },
    applyHeading5() {
      document.execCommand("formatBlock", false, "<h5>");
    },
    applyHeading6() {
      document.execCommand("formatBlock", false, "<h6>");
    },
    applyUnorderedList() {
      document.execCommand("insertUnorderedList");
    },
    applyOrderedList() {
      document.execCommand("insertOrderedList");
    },
    applyChecklist() {
      // TODO - implement checklist behavior (will need markdown-it extra module + custom html code to add the " - [ ] "")
    },
    insertHorizontalRule() {
      document.execCommand("insertHorizontalRule");
    },
    insertHyperlink() {
      console.log(this.hyperlink);
      document.execCommand("createLink", false, this.hyperlink);
    },
    insertImage() {
      document.execCommand("insertImage");
    },
    undo() {
      document.execCommand("undo");
    },
    redo() {
      document.execCommand("redo");
    },
  },
};
</script>

<style>
/* TODO - research and see if @apply is what should be used here */
.button {
  border: 2px solid gray;
  border-radius: 5px;
  padding: 5px;
  margin: 2px;
  background-color: white;
  color: black;
}

.button:hover {
  background-color: gray;
  color: white;
}

.dropdown {
  position: relative;
  display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  /* min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2); */
  z-index: 1;
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbutton {
  background-color: #3e8e41;
}
</style>
