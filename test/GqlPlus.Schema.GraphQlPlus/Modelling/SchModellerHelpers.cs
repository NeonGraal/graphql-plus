using System.Collections.Generic;
using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal static class SchModellerHelpers
{
  internal static ISch_Name MakeName(string name)
  {
    Sch_Name result = new();
    result.SetValue(name ?? string.Empty);
    return result;
  }

  internal static ICollection<string> Desc(string? description)
    => string.IsNullOrEmpty(description) ? [] : [description!];

  internal static ICollection<ISch_Name> MakeAliases(IEnumerable<string>? aliases)
    => [.. (aliases ?? []).Where(a => !string.IsNullOrWhiteSpace(a)).Select(MakeName)];

  internal static GqlpTypeKind LookupKind(string? name, IMap<GqlpTypeKind> typeKinds)
    => !string.IsNullOrWhiteSpace(name) && typeKinds.TryGetValue(name!, out GqlpTypeKind found)
      ? found
      : GqlpTypeKind.Basic;

  internal static Sch_TypeKind GqlpToSchTypeKind(GqlpTypeKind kind)
    => kind switch {
      GqlpTypeKind.Basic => Sch_TypeKind.Basic,
      GqlpTypeKind.Enum => Sch_TypeKind.Enum,
      GqlpTypeKind.Internal => Sch_TypeKind.Internal,
      GqlpTypeKind.Domain => Sch_TypeKind.Domain,
      GqlpTypeKind.Union => Sch_TypeKind.Union,
      GqlpTypeKind.Dual => Sch_TypeKind.Dual,
      GqlpTypeKind.Input => Sch_TypeKind.Input,
      GqlpTypeKind.Output => Sch_TypeKind.Output,
      _ => Sch_TypeKind.Basic,
    };

  internal static Sch_SimpleKind GqlpToSchSimpleKind(GqlpTypeKind kind)
    => kind switch {
      GqlpTypeKind.Enum => Sch_SimpleKind.Enum,
      GqlpTypeKind.Internal => Sch_SimpleKind.Internal,
      GqlpTypeKind.Domain => Sch_SimpleKind.Domain,
      GqlpTypeKind.Union => Sch_SimpleKind.Union,
      _ => Sch_SimpleKind.Basic,
    };

  internal static ISch_TypeRef<Sch_TypeKind> MakeTypeRef(string name, GqlpTypeKind kind, IMap<GqlpTypeKind> typeKinds)
  {
    GqlpTypeKind resolved = typeKinds.TryGetValue(name, out GqlpTypeKind found) ? found : kind;
    Sch_TypeRef<Sch_TypeKind> result = new();
    result.As__TypeRef = new Sch_TypeRefObject<Sch_TypeKind>([], MakeName(name), GqlpToSchTypeKind(resolved));
    return result;
  }

  internal static ISch_TypeSimple MakeTypeSimple(string typeName, IMap<GqlpTypeKind> typeKinds)
  {
    GqlpTypeKind kind = LookupKind(typeName, typeKinds);
    ISch_TypeRef<Sch_TypeKind> typeRef = MakeTypeRef(typeName, GqlpTypeKind.Basic, typeKinds);
    Sch_TypeSimple result = new() {
      As__TypeSimple = new Sch_TypeSimpleObject(),
    };

    switch (kind) {
      case GqlpTypeKind.Enum:
        result.As_TypeKindEnum = typeRef;
        break;
      case GqlpTypeKind.Domain:
        result.As_TypeKindDomain = typeRef;
        break;
      case GqlpTypeKind.Union:
        result.As_TypeKindUnion = typeRef;
        break;
      default:
        result.As_TypeKindBasic = typeRef;
        break;
    }

    return result;
  }

  internal static IDictionary<Sch_Location, GqlpUnit> MakeLocations(DirectiveLocation locations)
  {
    Dictionary<Sch_Location, GqlpUnit> result = [];
    AddIf(result, locations, DirectiveLocation.Operation, Sch_Location.Operation);
    AddIf(result, locations, DirectiveLocation.Variable, Sch_Location.Variable);
    AddIf(result, locations, DirectiveLocation.Field, Sch_Location.Field);
    AddIf(result, locations, DirectiveLocation.Inline, Sch_Location.Inline);
    AddIf(result, locations, DirectiveLocation.Spread, Sch_Location.Spread);
    AddIf(result, locations, DirectiveLocation.Fragment, Sch_Location.Fragment);
    return result;
  }

  internal static ISch_Named MakeNamedParent(IAstTypeRef? parent)
  {
    Sch_Named result = new();
    result.As__Named = new Sch_NamedObject(parent is null ? [] : Desc(parent.Description), MakeName(parent?.Name ?? string.Empty));
    return result;
  }

  internal static ISch_TypeParam MakeTypeParam(string name, string? description)
  {
    Sch_TypeParam result = new();
    result.As__TypeParam = new Sch_TypeParamObject(Desc(description), MakeName(name));
    return result;
  }

  internal static ISch_ObjBase EmptyObjBase()
  {
    Sch_ObjBase result = new();
    result.As__ObjBase = new Sch_ObjBaseObject([], MakeName(string.Empty), []);
    return result;
  }

  internal static ISch_Type MakeTypeShell(string name, IMap<GqlpTypeKind> typeKinds)
  {
    GqlpTypeKind kind = LookupKind(name, typeKinds);
    Sch_Type result = new() {
      As__Type = new Sch_TypeObject(),
    };

    switch (kind) {
      case GqlpTypeKind.Internal:
        result.As_TypeKindInternal = MakeBaseType(name, Sch_TypeKind.Internal);
        break;
      case GqlpTypeKind.Enum:
        result.As_TypeKindEnum = MakeEnumShell(name);
        break;
      case GqlpTypeKind.Domain:
        result.As_DomainKindString = MakeDomainShell(name);
        break;
      case GqlpTypeKind.Union:
        result.As_TypeKindUnion = MakeUnionShell(name);
        break;
      case GqlpTypeKind.Dual:
        result.As_TypeKindDual = MakeObjectShell<ISch_DualField>(name, Sch_TypeKind.Dual);
        break;
      case GqlpTypeKind.Input:
        result.As_TypeKindInput = MakeObjectShell<ISch_InputField>(name, Sch_TypeKind.Input);
        break;
      case GqlpTypeKind.Output:
        result.As_TypeKindOutput = MakeObjectShell<ISch_OutputField>(name, Sch_TypeKind.Output);
        break;
      default:
        result.As_TypeKindBasic = MakeBaseType(name, Sch_TypeKind.Basic);
        break;
    }

    return result;
  }

  private static Sch_BaseType<Sch_TypeKind> MakeBaseType(string name, Sch_TypeKind kind)
  {
    Sch_BaseType<Sch_TypeKind> result = new();
    result.As__BaseType = new Sch_BaseTypeObject<Sch_TypeKind>([], MakeName(name), [], kind);
    return result;
  }

  private static Sch_ParentType<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel> MakeEnumShell(string name)
  {
    Sch_ParentType<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel> result = new();
    result.As__ParentType = new Sch_ParentTypeObject<Sch_TypeKind, ISch_Aliased, ISch_EnumLabel>([], MakeName(name), [], Sch_TypeKind.Enum, MakeNamedParent(null), [], []);
    return result;
  }

  private static Sch_BaseDomain<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex> MakeDomainShell(string name)
  {
    Sch_BaseDomain<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex> result = new();
    result.As__BaseDomain = new Sch_BaseDomainObject<Sch_DomainKind, ISch_DomainRegex, ISch_DomainItemRegex>([], MakeName(name), [], MakeNamedParent(null), [], [], Sch_DomainKind.String);
    return result;
  }

  private static Sch_ParentType<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember> MakeUnionShell(string name)
  {
    Sch_ParentType<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember> result = new();
    result.As__ParentType = new Sch_ParentTypeObject<Sch_TypeKind, ISch_UnionRef, ISch_UnionMember>([], MakeName(name), [], Sch_TypeKind.Union, MakeNamedParent(null), [], []);
    return result;
  }

  private static Sch_TypeObject<Sch_TypeKind, TField> MakeObjectShell<TField>(string name, Sch_TypeKind kind)
    where TField : class
  {
    Sch_TypeObject<Sch_TypeKind, TField> result = new();
    result.As__TypeObject = new Sch_TypeObjectObject<Sch_TypeKind, TField>([], MakeName(name), [], kind, EmptyObjBase(), [], [], [], [], []);
    return result;
  }

  private static void AddIf(
    Dictionary<Sch_Location, GqlpUnit> result,
    DirectiveLocation input,
    DirectiveLocation flag,
    Sch_Location output
  )
  {
    if ((input & flag) == flag) {
      result[output] = new GqlpUnit();
    }
  }
}
