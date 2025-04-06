//HintName: Model_Intro_Object.gen.cs
// Generated from Intro_Object.graphql+

/*
*/

namespace GqlTest.Model_Intro_Object;

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
