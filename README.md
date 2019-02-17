![NuGet Downloads](https://img.shields.io/nuget/dt/Light.Reflector.svg?label=NuGet&style=flat-square)

# Light Reflector

## Abstract

- Ultra portable and light tool to map values from one object to another regardless of their types.

## Usage

```
LightReflector reflector = new LightReflector();

Dog bulldog = new Dog(
    id: 1, 
    name: "Terry", 
    race: "Bulldog", 
    age: 1
);
// [bulldog] id: 1, name: Terry, race: Bulldog, age: 1
RESTDog bulldogClone = new RESTDog(
    name: "", 
    race: "", 
    age: -1
);
// [bulldogClone] name: , race: , age: -1

reflector.AssignValues(from: bulldog, to: bulldogClone);

// [bulldog] id: 1, name: Terry, race: Bulldog, age: 1
// [bulldogClone] name: Terry, race: Bulldog, age: 1
```
