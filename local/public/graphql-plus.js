/** @type LanguageFn */
export default function (hljs) {
  const regex = hljs.regex;
  const GQL_NAME = /[_A-Za-z][_0-9A-Za-z]*/;
  return {
    name: "GraphQlPlus",
    aliases: ["gql-plus", "gqlp"],
    disableAutodetect: false,
    keywords: {
      keyword: ["category", "output", "input", "schema", "directive", "scalar", "enum"],
      literal: ["true", "false", "null", "_"],
    },
    contains: [
      hljs.HASH_COMMENT_MODE,
      hljs.QUOTE_STRING_MODE,
      hljs.NUMBER_MODE,
      {
        scope: "punctuation",
        match: /[.]{3}/,
        relevance: 0,
      },
      {
        scope: "punctuation",
        begin: /[\!\(\)\:\=\[\]\{\|\}]{1}/,
        relevance: 0,
      },
      {
        scope: "variable",
        begin: /\$/,
        end: /\W/,
        excludeEnd: true,
        relevance: 0,
      },
      {
        scope: "meta",
        match: /@\w+/,
        excludeEnd: true,
      },
      {
        scope: "symbol",
        begin: regex.concat(GQL_NAME, regex.lookahead(/\s*[:=]/)),
        relevance: 0,
      },
    ],
    illegal: [/[;<']/, /BEGIN/],
  };
}
