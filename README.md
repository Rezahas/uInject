# uInject
Dependency Injection for Unity3D

Simple Dependency Injection for Unity3D, built on top of Ninject (http://www.ninject.org/).

# Setup Instructions
THESE INSTRUCTIONS ONLY COVER HOW TO SETUP YOUR UNITY PROJECT FOR DEPENDENCY INJECTION. FOR INFORMATION ON HOW TO USE NINJECT CONSULT THEIR TUTORIALS AT http://www.ninject.org/learn.html

1. Initialize the Kernel:
To enable dependency injection for your project, you have to setup the Kernel, which will handle all injection.
You can find the standard Unity Kernel under Assets/uInject/Prefabs/. Simply pull the prefab into your startup scene.
Make sure that the KernelInitializer script is the first entry in your script execution order. The script execution order can be found under Edit->Project Settings->Script Execution Order.

2. Add a Binder:
To add a Binder to your Kernel, you first have to create a subclass of the BinderMono. Simply override the Bind(Ninject.Syntax.IBindingRoot binding) function and add your bindings as you would in Ninject.
Add one or multiple Binders to the GameObject that has the KernelInitializer. For larger projects with a lot of modules it is beneficial to add your Binders to childs of that GameObject.

3. How to use injection with MonoBehaviours:
To make MonoBehaviours applicable for dependency injection, simply exchange the "<class name> : MonoBehaviour" with "<class name> : DIMono". The DIMono has virtual Members of all commonly used
MonoBehaviour functions (i.e. Start, Update), so you have to use the override keyword, instead of just declaring these functions in your class.
Also, if you override the Awake function, make sure that you put a "base.Awake()" in in it, otherwise injection will not occur.

4. Add Prefabs and Scriptable Objects bindings:
If your want to use some kind of Prefab- or ScriptableObject-Provider in your project, you have to setup special bindings in your binder classes.
Simply open up your binder in the Inspector and add entries to "Prefab Bindings" and/or "Scriptable Object Bindings". For the Type you put the name (without namespace) of your implementing class.
Drag the Prefab or Scriptable Object into the corresponding field. To use these Prefabs/Scriptable Objects in your applications, create bindings in your Binder-class.
(i.e. binding.Bind<AsteroidSpawner>().ToProvider<PrefabProvider<AsteroidSpawnerImpl>>().InSingletonScope();)

5. Also take a look at the examples under Assets/uInject/Examples. For questions/suggestions/bug reports/words of encouragement you can contact me via the git repository (https://github.com/Rezahas/uInject/),
the Unity3D forums (http://forum.unity3d.com/members/rezahas.832830/) or e-mail (support@rezahas.com). Please keep in mind that I am doing this in my free time and don't charge for this software,
although I will try to get back to you as soon as possible, it may take several days.

6. You are very welcome to fork the project on github and make pull requests so everyone can benifit from your improvements!
