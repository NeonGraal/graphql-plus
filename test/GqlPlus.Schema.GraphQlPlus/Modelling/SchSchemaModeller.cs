using System.Collections.Generic;
using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchSchemaModeller(
  IModeller<IAstSchemaCategory, ISch_Category> categoryModeller,
  IModeller<IAstSchemaDirective, ISch_Directive> directiveModeller,
  IModeller<IAstSchemaSetting, ISch_Setting> settingModeller,
  IModeller<IAstTypeSpecial, ISch_Type> specialModeller,
  IModeller<IAstEnum, ISch_Type> enumModeller,
  IModeller<IAstUnion, ISch_Type> unionModeller,
  IModeller<IAstDomain<IAstDomainTrueFalse>, ISch_Type> domainBooleanModeller,
  IModeller<IAstDomain<IAstDomainLabel>, ISch_Type> domainEnumModeller,
  IModeller<IAstDomain<IAstDomainRange>, ISch_Type> domainNumberModeller,
  IModeller<IAstDomain<IAstDomainRegex>, ISch_Type> domainStringModeller,
  IModeller<IAstObject<IAstDualField>, ISch_Type> dualModeller,
  IModeller<IAstObject<IAstInputField>, ISch_Type> inputModeller,
  IModeller<IAstObject<IAstOutputField>, ISch_Type> outputModeller
) : ModellerBase<IAstSchema, ISch_SchemaObject>
{
  private readonly IModeller<IAstSchemaCategory, ISch_Category> _categoryModeller = categoryModeller;
  private readonly IModeller<IAstSchemaDirective, ISch_Directive> _directiveModeller = directiveModeller;
  private readonly IModeller<IAstSchemaSetting, ISch_Setting> _settingModeller = settingModeller;
  private readonly IModeller<IAstTypeSpecial, ISch_Type> _specialModeller = specialModeller;
  private readonly IModeller<IAstEnum, ISch_Type> _enumModeller = enumModeller;
  private readonly IModeller<IAstUnion, ISch_Type> _unionModeller = unionModeller;
  private readonly IModeller<IAstDomain<IAstDomainTrueFalse>, ISch_Type> _domainBooleanModeller = domainBooleanModeller;
  private readonly IModeller<IAstDomain<IAstDomainLabel>, ISch_Type> _domainEnumModeller = domainEnumModeller;
  private readonly IModeller<IAstDomain<IAstDomainRange>, ISch_Type> _domainNumberModeller = domainNumberModeller;
  private readonly IModeller<IAstDomain<IAstDomainRegex>, ISch_Type> _domainStringModeller = domainStringModeller;
  private readonly IModeller<IAstObject<IAstDualField>, ISch_Type> _dualModeller = dualModeller;
  private readonly IModeller<IAstObject<IAstInputField>, ISch_Type> _inputModeller = inputModeller;
  private readonly IModeller<IAstObject<IAstOutputField>, ISch_Type> _outputModeller = outputModeller;

  protected override ISch_SchemaObject ToModel(IAstSchema ast, IMap<GqlpTypeKind> typeKinds)
  {
    IAstType[] typeDeclarations = [.. ast.Declarations.OfType<IAstType>()];
    AddTypeKinds(typeDeclarations, typeKinds);

    Dictionary<string, ISch_Type> typesByName = [];
    Dictionary<ISch_Name, ISch_Type> types = [];
    foreach (IAstType declaration in typeDeclarations) {
      ISch_Type type = ToType(declaration, typeKinds);
      typesByName[declaration.Name] = type;
      types[SchModellerHelpers.MakeName(declaration.Name)] = type;
    }

    Dictionary<ISch_Name, ISch_Categories> categories = [];
    foreach (IAstSchemaCategory declaration in ast.Declarations.OfType<IAstSchemaCategory>()) {
      ISch_Category category = _categoryModeller.ToModel(declaration, typeKinds);
      ISch_Type type = ResolveType(declaration.Output.Name, typesByName, typeKinds);
      categories[SchModellerHelpers.MakeName(declaration.Name)] = MakeCategories(declaration, type, category);
    }

    Dictionary<ISch_Name, ISch_Directives> directives = [];
    foreach (IAstSchemaDirective declaration in ast.Declarations.OfType<IAstSchemaDirective>()) {
      ISch_Directive directive = _directiveModeller.ToModel(declaration, typeKinds);
      string typeName = declaration.Parameter?.Type.Name ?? declaration.Name;
      ISch_Type type = ResolveType(typeName, typesByName, typeKinds);
      directives[SchModellerHelpers.MakeName(declaration.Name)] = MakeDirectives(declaration, type, directive);
    }

    Dictionary<ISch_Name, ISch_Setting> settings = [];
    foreach (IAstSchemaSetting setting in ast.Declarations.OfType<IAstSchemaOption>().SelectMany(option => option.Settings)) {
      settings[SchModellerHelpers.MakeName(setting.Name)] = _settingModeller.ToModel(setting, typeKinds);
    }

    string schemaName = ast.Declarations
      .OfType<IAstSchemaOption>()
      .Select(option => option.Name)
      .LastOrDefault(name => !string.IsNullOrWhiteSpace(name))
      ?? string.Empty;

    return new SchSchemaImplementation([], SchModellerHelpers.MakeName(schemaName), categories, directives, types, settings);
  }

  private static void AddTypeKinds(IEnumerable<IAstType> declarations, IMap<GqlpTypeKind> typeKinds)
  {
    foreach (IAstType declaration in declarations) {
      GqlpTypeKind kind = declaration switch {
        IAstTypeSpecial { Kind: TypeKind.Internal } => GqlpTypeKind.Internal,
        IAstTypeSpecial => GqlpTypeKind.Basic,
        IAstEnum => GqlpTypeKind.Enum,
        IAstUnion => GqlpTypeKind.Union,
        IAstDomain<IAstDomainTrueFalse> => GqlpTypeKind.Domain,
        IAstDomain<IAstDomainLabel> => GqlpTypeKind.Domain,
        IAstDomain<IAstDomainRange> => GqlpTypeKind.Domain,
        IAstDomain<IAstDomainRegex> => GqlpTypeKind.Domain,
        IAstObject<IAstDualField> => GqlpTypeKind.Dual,
        IAstObject<IAstInputField> => GqlpTypeKind.Input,
        IAstObject<IAstOutputField> => GqlpTypeKind.Output,
        _ => GqlpTypeKind.Basic,
      };

      if (typeKinds.TryGetValue(declaration.Name, out GqlpTypeKind existing)) {
        if (existing != kind) {
          throw new InvalidOperationException($"Type '{declaration.Name}' has multiple kinds: {existing} and {kind}.");
        }
      } else {
        typeKinds.Add(declaration.Name, kind);
      }
    }
  }

  private ISch_Type ToType(IAstType declaration, IMap<GqlpTypeKind> typeKinds)
    => declaration switch {
      IAstTypeSpecial special => _specialModeller.ToModel(special, typeKinds),
      IAstEnum enumType => _enumModeller.ToModel(enumType, typeKinds),
      IAstUnion union => _unionModeller.ToModel(union, typeKinds),
      IAstDomain<IAstDomainTrueFalse> domain => _domainBooleanModeller.ToModel(domain, typeKinds),
      IAstDomain<IAstDomainLabel> domain => _domainEnumModeller.ToModel(domain, typeKinds),
      IAstDomain<IAstDomainRange> domain => _domainNumberModeller.ToModel(domain, typeKinds),
      IAstDomain<IAstDomainRegex> domain => _domainStringModeller.ToModel(domain, typeKinds),
      IAstObject<IAstDualField> dual => _dualModeller.ToModel(dual, typeKinds),
      IAstObject<IAstInputField> input => _inputModeller.ToModel(input, typeKinds),
      IAstObject<IAstOutputField> output => _outputModeller.ToModel(output, typeKinds),
      _ => throw new InvalidOperationException($"Unsupported schema type '{declaration.GetType().Name}'."),
    };

  private static ISch_Type ResolveType(string name, Dictionary<string, ISch_Type> typesByName, IMap<GqlpTypeKind> typeKinds)
    => typesByName.TryGetValue(name, out ISch_Type? type)
      ? type
      : SchModellerHelpers.MakeTypeShell(name, typeKinds);

  private static Sch_Categories MakeCategories(IAstSchemaCategory ast, ISch_Type type, ISch_Category category)
    => new Sch_Categories {
      As_Type = type,
      As_Category = category,
      As__Categories = new Sch_CategoriesObject(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        type,
        category),
    };

  private static Sch_Directives MakeDirectives(IAstSchemaDirective ast, ISch_Type type, ISch_Directive directive)
    => new Sch_Directives {
      As_Type = type,
      As_Directive = directive,
      As__Directives = new Sch_DirectivesObject(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        type,
        directive),
    };
}
