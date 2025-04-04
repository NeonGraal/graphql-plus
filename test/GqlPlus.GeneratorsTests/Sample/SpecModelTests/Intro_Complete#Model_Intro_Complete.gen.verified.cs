//HintName: Model_Intro_Complete.gen.cs
// Generated from Intro_Complete.graphql+

/*
*/

namespace GqlTest.Model_Intro_Complete;

public interface IOutput_Schema {}

public interface IDomain_Identifier {
  string Value { get; set; }
}
public class Domain_Identifier
  : IDomain_Identifier
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IInput_Filter {}

public interface IDomain_NameFilter {
  string Value { get; set; }
}
public class Domain_NameFilter
  : IDomain_NameFilter
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IInput_CategoryFilter {}

public interface IInput_TypeFilter {}

public interface IDual_Aliased {}

public interface IDual_Named {}

public interface IDual_Described {}

public interface IOutput_Categories {}

public interface IOutput_Category {}

public enum _Resolution {
  Parallel,
  Sequential,
  Single,
}

public interface IOutput_Directives {}

public interface IOutput_Directive {}

public enum _Location {
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public interface IOutput_Setting {}

public interface IOutput_Type {}

public interface IOutput_BaseType {}

public interface IOutput_ChildType {}

public interface IOutput_ParentType {}

public enum _SimpleKind {
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum _TypeKind {
  Basic = _SimpleKind.Basic,
  Enum = _SimpleKind.Enum,
  Internal = _SimpleKind.Internal,
  Domain = _SimpleKind.Domain,
  Union = _SimpleKind.Union,
  Dual,
  Input,
  Output,
}

public interface IOutput_TypeRef {}

public interface IOutput_TypeSimple {}

public interface IOutput_Constant {}

public interface IOutput_Simple {}

public interface IOutput_ConstantList {}

public interface IOutput_ConstantMap {}

public interface IOutput_Collections {}

public interface IOutput_ModifierKeyed {}

public interface IOutput_Modifiers {}

public enum _ModifierKind {
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface IOutput_Modifier {}

public enum _DomainKind {
  Boolean,
  Enum,
  Number,
  String,
}

public interface IOutput_TypeDomain {}

public interface IOutput_DomainRef {}

public interface IOutput_BaseDomain {}

public interface IDual_BaseDomainItem {}

public interface IOutput_DomainItem {}

public interface IOutput_DomainValue {}

public interface IDual_DomainTrueFalse {}

public interface IOutput_DomainItemTrueFalse {}

public interface IOutput_DomainLabel {}

public interface IOutput_DomainItemLabel {}

public interface IDual_DomainRange {}

public interface IOutput_DomainItemRange {}

public interface IDual_DomainRegex {}

public interface IOutput_DomainItemRegex {}

public interface IOutput_TypeEnum {}

public interface IDual_EnumLabel {}

public interface IOutput_EnumValue {}

public interface IOutput_TypeUnion {}

public interface IOutput_UnionRef {}

public interface IOutput_UnionMember {}

public interface IOutput_TypeObject {}

public interface IOutput_ObjConstraint {}

public interface IOutput_ObjType {}

public interface IOutput_ObjBase {}

public interface IOutput_ObjTypeArg {}

public interface IDomain_TypeParam : IDomain_Identifier {
  string Value { get; set; }
}
public class Domain_TypeParam
  : Domain_Identifier
  , IDomain_TypeParam
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IOutput_ObjTypeParam {}

public interface IOutput_Alternate {}

public interface IOutput_ObjectFor {}

public interface IOutput_Field {}

public interface IOutput_TypeDual {}

public interface IOutput_DualBase {}

public interface IOutput_DualField {}

public interface IOutput_DualAlternate {}

public interface IOutput_DualTypeArg {}

public interface IOutput_TypeInput {}

public interface IOutput_InputBase {}

public interface IOutput_InputField {}

public interface IOutput_InputAlternate {}

public interface IOutput_InputTypeArg {}

public interface IOutput_InputParam {}

public interface IOutput_TypeOutput {}

public interface IOutput_OutputBase {}

public interface IOutput_OutputField {}

public interface IOutput_OutputAlternate {}

public interface IOutput_OutputTypeArg {}

public interface IOutput_OutputEnum {}
