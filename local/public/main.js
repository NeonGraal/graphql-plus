import peg from "./peg.js";
import graphqlPlus from "./graphql-plus.js";

export default {
  configureHljs: function (hljs) {
    hljs.registerLanguage("peg", peg);
    hljs.registerLanguage("graphql-plus", graphqlPlus);
  },
};
