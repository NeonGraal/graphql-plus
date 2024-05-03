﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema;

internal class VerifySchema(
  IVerifyUsage<CategoryDeclAst, OutputDeclAst> categoryOutputs,
  IVerifyUsage<DirectiveDeclAst, InputDeclAst> directiveInputs,
  IVerifyAliased<OptionDeclAst> optionsAliased,
  IVerifyAliased<AstType> typesAliased,
  IVerify<AstType[]> types
) : IVerify<IGqlpSchema>
{
  public void Verify(IGqlpSchema item, ITokenMessages errors)
  {
    CategoryDeclAst[] categories = item.Declarations.ArrayOf<CategoryDeclAst>();
    DirectiveDeclAst[] directives = item.Declarations.ArrayOf<DirectiveDeclAst>();
    OptionDeclAst[] options = item.Declarations.ArrayOf<OptionDeclAst>();
    AstType[] astTypes = item.Declarations.ArrayOf<AstType>();
    IEnumerable<AstType> allTypes = astTypes.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal);

    categoryOutputs.Verify(new(categories, allTypes.ArrayOf<OutputDeclAst>()), errors);

    directiveInputs.Verify(new(directives, allTypes.ArrayOf<InputDeclAst>()), errors);

    optionsAliased.Verify(options, errors);

    types.Verify(astTypes, errors);
    typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);
  }
}
