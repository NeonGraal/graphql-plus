//HintName: Model_Intro_Complete.gen.cs
// Generated from Intro_Complete.graphql+

/*
*/

namespace GqlTest.Model_Intro_Complete;

public interface IOutput_Schema {}

public interface IDomain_Identifier {}

public interface IInput_Filter {}

public interface IDomain_NameFilter {}

public interface IInput_CategoryFilter {}

public interface IInput_TypeFilter {}

public interface IDual_Aliased {}

public interface IDual_Described {}

public interface IDual_Named {}

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

public enum _TypeKind : _SimpleKind {
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

public interface IOutput_DomainMember {}

public interface IOutput_DomainItemMember {}

public interface IDual_DomainRange {}

public interface IOutput_DomainItemRange {}

public interface IDual_DomainRegex {}

public interface IOutput_DomainItemRegex {}

public interface IOutput_TypeEnum {}

public interface IDual_EnumMember {}

public interface IOutput_EnumValue {}

public interface IOutput_TypeUnion {}

public interface IDual_UnionMember {}

public interface IOutput_TypeObject {}

public interface IDual_ObjDescribed {}

public interface IOutput_ObjType {}

public interface IOutput_ObjBase {}

public interface IOutput_ObjArg {}

public interface IDomain_TypeParam : _Identifier {}

public interface IOutput_Alternate {}

public interface IOutput_ObjectFor {}

public interface IOutput_Field {}

public interface IOutput_TypeDual {}

public interface IOutput_DualBase {}

public interface IOutput_DualParent {}

public interface IOutput_DualField {}

public interface IOutput_DualAlternate {}

public interface IOutput_TypeInput {}

public interface IOutput_InputBase {}

public interface IOutput_InputParent {}

public interface IOutput_InputField {}

public interface IOutput_InputAlternate {}

public interface IOutput_InputParam {}

public interface IOutput_TypeOutput {}

public interface IOutput_OutputBase {}

public interface IOutput_OutputParent {}

public interface IOutput_OutputField {}

public interface IOutput_OutputAlternate {}

public interface IOutput_OutputArg {}

public interface IOutput_OutputEnum {}
